# AdventOfCode2020
Advent of Code 2020 solution. See below for explanations.

## Solution Layout

    Program.cs // Call the various classes.
    Day01.cs...Day25.cs // Classes for each puzzle.
    Helpers.cs // Stuff I may use later.
    Inputs\DayXXInput.txt // Where the inputs are read from.

Notes:
- I like LINQ. It's quick and easy. This whole repo is likely to be one big old LINQ tutorial.
- This is a contest where speed is rewarded, so while classes are preferable, I'll likely be using a lot of tuples.
- I'll try to acknowledge sources I use, but I may very well grab something from my own repos that I've used and not included the source. If I use your code, let me know, and I'll make a note of it.

## Day 01
[Link to Puzzle](https://adventofcode.com/2020/day/1)

### Part 01
Simple enough with some for loops. You can throw some checks in there like there's no need to continue if the first number is already bigger than the target number, but with this small data set, why bother.

### Part 02
Just throw in a third for loop, right?

Well, yes. That's definitely a possibility. But real world, I'm already starting to see growth issues with this. What about checking four numbers? Seven? 812? Maybe we should do something different?

Using a combination function and limiting the set size, we can easily update the function if the Elves in accounting decide they want more data.

## Day 02

[Link to Puzzle](https://adventofcode.com/2020/day/2)

### Part 01

This one is even easier than Day 01, in my opinion. The most challenging part of this puzzle is getting your input data. I used string.Split, but regex is always an option. From there, it's simply a matter of getting your password into an array of characters and voila.

### Part 02

Again, no big deal, although you may not use XOR enough to remember it's ^ in C#. Also, no, I didn't have to use a ternary for the two parts; I just like the thought of it all being a single line.
