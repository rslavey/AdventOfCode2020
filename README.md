# AdventOfCode2020

My solutions for the Advent of Code 2020. As a learning experience, I am attempting to use LINQ wherever possible, even if it's not the most practical. If you find yourself saying, "That's a massive LINQ statement. You could just use 5 lines of code in a loop," rest assured, it's on purpose.

## Solution Layout

|File(s)|Purpose|
|---|---|
|[Program.cs](AdventOfCode2020/Program.cs)|Call the various classes.|
|`YEAR`\Day01`YEAR`.cs|Classes for each puzzle|
|[Helpers.cs](AdventOfCode2020/Helpers.cs)|Stuff I may use later.|
|Inputs\\`YEAR`\\DayXXInput.txt|Where the inputs are read from.|

**I'll try to acknowledge sources I use, but I may very well grab something from my own repos that I've used and not included the source. If I use your code, let me know, and I'll make a note of it.**

## TOC

- [Day 1: Report Repair](#day-1-report-repair)
- [Day 2: Password Philosophy](#day-2-password-philosophy)
- [Day 3: Toboggan Trajectory](#day-3-toboggan-trajectory)
- [Day 4: Passport Processing](#day-4-passport-processing)
- [Day 5: Binary Boarding](#day-5-binary-boarding)

---

## Day 1: Report Repair

- [Link to Puzzle](https://adventofcode.com/2020/day/1)
- [Class](AdventOfCode2020/2020/Day012020.cs)
- [Helpers](AdventOfCode2020/Helpers.cs)

Things to Know:
- Using LINQ `Aggregate()` to multiply numbers in a list
- For...Next loops or Recursive Functions
- Combinations

(h/t to [GeeksforGeeks](https://www.geeksforgeeks.org/print-all-possible-combinations-of-r-elements-in-a-given-array-of-size-n/) for the combination function)

### Part 01

This is a speed contest, so the temptation to nest some loops is great. Resist it. There's nothing wrong with a nested loop here and there, but it can almost always be done better with recursion. My general rule is if you're copy/pasting code over and over, rethink what it is you're trying to accomplish.

So what are you looking for? This is a standard combination problem where you have to combine all the numbers in a list. Unlike, say, combining two dice where you can have a 1 and a 1, you don't want to combine a number with itself, so your loop/recursion should always check all the numbers *after* the current number only.

*Note: Read up on the difference between combinations and permutations. You'll likely run across both at some point.*

### Part 02

See? Because you planned ahead, you are going to just change the set size for the combination function while everyone else is copy/pasting their loops and hoping they remembered to use the right index variable in the right loop.

### LINQ Explanations

    InputValues.AddRange(File.ReadAllLines(filePath).Select(x => int.Parse(x)));

This is a LINQ replacement for a loop. You can add the entire `string[]` at once to the List<int> by using `Select` and parsing in the lambda.

    return list.Aggregate(1, (acc, val) => acc * val)

Again, skip the loops. This small bit of LINQ replaces the following:

    int product = 1;
    foreach (int n in list) {
        product *= n;
    }
    return n;

---

## Day 2: Password Philosophy

- [Link to Puzzle](https://adventofcode.com/2020/day/2)
- [Class](AdventOfCode2020/2020/Day022020.cs)
 
Things to Know:
- `.ToCharArray()` to run LINQ queries against a string's characters
- `.Split()` to break a string into an array of strings (e.g. comma-separated text)
- How to use XOR when you want to know when *only one* condition is true. The XOR comparator in C# is `^`
- Ternary operators
- Tuples
- `Enumerable.Range()` to check if a value is between two other values.

Likely Places to Make Mistakes
- Arrays are zero based. Some problems are 1 based arrays.
- Make your operators <= and >= so they're inclusive.
- XOR not OR

### Part 01

First, we need to break up the input into values we can use. Normally, you would use plenty of data validation, but we can probably trust that this data has been checked enough not to worry about it here, so just use your `Split()` and get your parts.

    List<(int lowReq, int highReq, char letter, string pass)>

If you're not familiar with .NET tuples, this is probably a little weird. Think of it as a simplification of a struct:

    struct ElfPassword {
        int lowReq;
        int highReq;
        char letter;
        string pass;
    }
    List<ElfPassword>

It's not exactly the same, but you get the point.

Now we just count the instances of a letter (using `.ToCharArray()` and `.Count()`) and check if it falls within our defined range. You can do this two ways:

    (minVal <= testVal && testVal <= maxVal)

or

    Enumerable.Range(minVal, maxVal - minVal + 1).Contains(testVal)

So why would you use the second when the first is shorter? Because I'm using `testVal` and not the real code of `x.pass.ToCharArray().Count(xx => xx == x.letter)`. Not having that in the lambda twice makes it easier to read.

Okay, I'm kidding. This is simply a stupid use of `Enumerable.Range()`, done for no other reason than to introduce `Enumerable.Range()`. The performance will be abysmal as the system has to generate all the numbers between `minVal` and `maxVal` before checking the test. Also, it only works with integers. Just don't do this.

### Part 02

Use the `.ToCharArray()` again to find letters at specific locations, remembering that the problem is using 1-based arrays. Also, don't forget they want one *and only one*. You'll need to use XOR instead of OR.

#### Ternary Operators

I like ternaries. There's just something about the formatting that seems more logical to me than a bunch of if/then/else statements. 

e.g.

    return x < y ? -1 : x > y ? 1 : 0;

vs.

    if (x < y) {
        return -1;
    }
    else if (x > y) {
        return 1;
    }
    else {
        return 0;
    }

Also, if you tell me I could have written it this way, you're dead to me:

    if (x < y) return -1;
    else if (x > y) return 1;
    else return 0;

### LINQ Explanations

Sometimes I'll find myself writing things like `list.Where(x => x == 0).FirstOrDefault();`. I don't know why I do it, but it's unnecessary. Same applies to `Count()`:

    list.Where(x => x == 0).Count()

is the same as

    list.Count(x => x == 0);

---

## Day 3: Toboggan Trajectory

- [Link to Puzzle](https://adventofcode.com/2020/day/3)
- [Class](AdventOfCode2020/2020/Day032020.cs)
 
Things to Know:
- You can get the index of a generic list by doing `list.Select((item, index) => new { item, index })`
- Modulo

Likely Places to Make Mistakes
- Line 1, the zero index, will never be used in the calculation as you always start at 0,0 and you always move before checking for tree.

### Part 01

This problem can be very confusing if you're not familiar with modulo. Often used to find even or odd numbers, modulo is simply the remainder of the division of two numbers.

So, in the case of:

    #....#....

we have trees at position 0 and 5. This is easy enough to determine when we've moved to the right 0-9 spaces, but what happens when we move right one more? We simply wrap back around. While the quotient will change, the remainder will always correspond with the horizontal value no matter how large the move.

e.g.

    0 % 10 = 0 // tree
    3 % 10 = 3 // no tree
    5 % 10 = 5 // tree
    25 % 10 = 5 // tree
    93 % 10 = 3 // no tree
    8488 % 10 = 8 // no tree

As for moving horizontally, we just need to check that the row we're testing (or list index in our problem) is evenly divisible by the downward movement distance.

e.g.

    //Right 1, down 1
    1 % 1 = 0 // check this row for trees
    2 % 1 = 0 // check this row for trees
    3 % 1 = 0 // check this row for trees

    //Right 1, down 2
    1 % 2 = 1 // don't check this row
    2 % 2 = 0 // check this row
    18 % 2 = 0 // check this row

### Part 02

You did use variables for the 3 and 1, right? If not, no worries. Make them parameters in your function and replace them now. Once you've done that, you can reuse your logic for part two. Get the tree count for all the movements and multiply them (use the `Aggregate()` from Day 01).

### LINQ Explanations

You can get the index of a generic list by doing `list.Select((item, index) => new { item, index })`

---

## Day 4: Passport Processing

- [Link to Puzzle](https://adventofcode.com/2020/day/4)
- [Class](AdventOfCode2020/2020/Day042020.cs)
 
Things to Know:
- Regular Expressions
- Dictionaries

Likely Places to Make Mistakes
- It's regex. There are 12,443 places to make mistakes

### Part 01

This problem becomes much easier if we can get our data into a Dictionary right away. Read the data and group the batches together into a `Dictionary<string, string>`. Then put all those into a collection.

Now it's a simple matter of checking each dictionary for the existence of the required keys.

### Part 02

Regex!

If you don't love regex, you're going to hate this part. If you are a fan, this was quick and easy. Here are the regex strings I used:

|Regex|Use|
|---|---|
|^([0-9]{4})$|4 digit year|
|^([0-9]+)(cm\|in)$|height|
|^#(?:[0-9a-fA-F]{6})$|hex color|
|^(?:amb\|blu\|brn\|gry\|grn\|hzl\|oth)$|eye color|
|^(?:[0-9]{9})$|pid|

### LINQ Explanations

Just look at this big old LINQ statement to turn a batch of garbage text into clean `Dictionary` items. A thing of beauty is a joy forever.

    GroupedInputs.Select(x => x.SelectMany(xx => xx.Split(' ')).Select(xx => new KeyValuePair<string, string>(xx.Split(':')[0], xx.Split(':')[1])).ToDictionary(xxx => xxx.Key, xxx => xxx.Value))

`SelectMany` -- Flatten the batch so instead of `{ { "a", "b", "c"}, { "d", "e", "f" } }` you have `{ "a", "b", "c", "d", "e", "f" }`

`KeyValuePair` -- Split each string by `:` and put the left into the `Key` and the right into the `Value` of a KeyValuePair

`ToDictionary` -- Take the collection of `KeyValuePair` items and turn it into a dictionary

---

## Day 5: Binary Boarding

- [Link to Puzzle](https://adventofcode.com/2020/day/5)
- [Class](AdventOfCode2020/2020/Day052020.cs)
 
Things to Know:
- Binary / base 2 numbering

Likely Places to Make Mistakes
- Overthinking the problem

### Part 01

This one is cleverly annoying. They took an entire page of text to basically define base 2 numbering. Once you realize that, and modify the inputs accordingly, this becomes quite simple.

    F|L = 0, B|R = 1

We can do a simple string replace, but we've already been playing with Regex, so let's keep it going.

    Regex.Replace(x, @"\w", xx => xx.Value == "R" || xx.Value == "B" ? "1" : "0")

This takes the whole word and for each letter, replaces R and B with 1 and everything else with 0. Getting the largest from here is just a matter of calling `Max()` against the collection.

### Part 02

Remember when I joked about how `Enumerable.Range()` was stupid to use. Well, it may have been there, but here it's a nice hack. Basically take *all* the numbers from the `Min()` to the `Max()` of the collection and find the missing number from the set.

    Enumerable.Range(ValsInBase2.Min(), ValsInBase2.Max() - ValsInBase2.Min() + 1).Except(ValsInBase2).FirstOrDefault();

The beauty of this one is that you can leave off the `FirstOrDefault()` and get all of the missing boarding passes if you, say, lost your entire family's passes.

### LINQ Explanations

Here are some useful methods similar to `Except()` for working with two lists:

    var s1 = new List<int> { 0, 1, 2, 3, 5 };
    var s2 = new List<int> { 0, 1, 2, 3, 4 };

    Console.WriteLine(string.Join(", ", s1.Except(s2)));
    Console.WriteLine(string.Join(", ", s2.Except(s1)));
    Console.WriteLine(string.Join(", ", s1.Intersect(s2)));
    Console.WriteLine(string.Join(", ", s1.Union(s2)));
    Console.WriteLine(string.Join(", ", s1.Concat(s2)));

Result:

    5
    4
    0, 1, 2, 3
    0, 1, 2, 3, 5, 4
    0, 1, 2, 3, 5, 0, 1, 2, 3, 4

---

## Day 6: Custom Customs

- [Link to Puzzle](https://adventofcode.com/2020/day/6)
- [Class](AdventOfCode2020/2020/Day062020.cs)
 
Things to Know:
- Okay, I swear I'm not privy to what's coming next, but look at yesterday's LINQ explanations

Likely Places to Make Mistakes
- No idea

### Part 01

This is going to be a really short explanation. This puzzle is basic `Union` and `Intersect` from LINQ. Take your group, do a `Union` with all the character arrays, add them up, and Bob's your uncle.

### Part 02

See Part 01. Repeat but with `Intersect`

### LINQ Explanations

This was kind of fun. Rather than a loop in my program, I wrote an overload that takes a collection of strings, turns each into a character array, does the various `Intersect`, `Union`, `Concat`, and `Except` functions as appropriate, and returns the result.

    internal static string Except(this IEnumerable<string> inputs)
    {
        var temp = inputs.FirstOrDefault().ToCharArray();
        foreach (var item in inputs.Skip(1))
        {
            temp = temp.Except(item).ToArray();
        }
        return new string(temp);
    }

    internal static string Concat(this IEnumerable<string> inputs)
    {
        var temp = inputs.FirstOrDefault().ToCharArray();
        foreach (var item in inputs.Skip(1))
        {
            temp = temp.Concat(item).ToArray();
        }
        return new string(temp);
    }

    internal static string Intersect(this IEnumerable<string> inputs)
    {
        var temp = inputs.FirstOrDefault().ToCharArray();
        foreach (var item in inputs.Skip(1))
        {
            temp = temp.Intersect(item).ToArray();
        }
        return new string(temp);
    }

    internal static string Union(this IEnumerable<string> inputs)
    {
        var temp = inputs.FirstOrDefault().ToCharArray();
        foreach (var item in inputs.Skip(1))
        {
            temp = temp.Union(item).ToArray();
        }
        return new string(temp);
    }

Now, if I call `Union()` (note the empty parameters where the LINQ extension requires another list to combine with, e.g. `list1.Union(list2)`), It runs against all the items within the list:

    var strings = new List<string> { "abc", "abz", "azz" };

    Console.WriteLine(strings.Union());
    Console.WriteLine(strings.Intersect());
    Console.WriteLine(strings.Except());
    Console.WriteLine(strings.Concat());

    -----

    abcz
    a
    c
    abcabzazz

Note: Using `Except`, the order does matter. In this case, it takes `abc` and removes the letters that are in `abz`, leaving `c`. Then it removes the letters from `c` that are in `azz` (none), leaving `c`. If you were to reorder the sets, you would get a different result.


---