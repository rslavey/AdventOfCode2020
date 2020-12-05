using com.randyslavey.AdventOfCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace com.randyslavey.AdventOfCode2020
{
    class Day052020 : IAdventOfCode
    {
        public int Result { get; set; }
        public string[] InputValues { get; set; }
        private IEnumerable<int> ValsInBase2 { get; set; }
        public string GetSolution(int part)
        {
            Result = part == 1 ?
                ValsInBase2.Max() :
                Enumerable.Range(ValsInBase2.Min(), ValsInBase2.Max() - ValsInBase2.Min() + 1).Except(ValsInBase2).FirstOrDefault();

            var s1 = new List<int> { 0, 1, 2, 3, 5 };
            var s2 = new List<int> { 0, 1, 2, 3, 4 };

            Console.WriteLine(string.Join(", ", s1.Except(s2)));
            Console.WriteLine(string.Join(", ", s2.Except(s1)));
            Console.WriteLine(string.Join(", ", s1.Intersect(s2)));
            Console.WriteLine(string.Join(", ", s1.Union(s2)));
            Console.WriteLine(string.Join(", ", s1.Concat(s2)));

            return $"{Result}";
        }

        public void GetInputData(string filePath)
        {
            InputValues = File.ReadAllLines(filePath);
            ValsInBase2 = InputValues.Select(x => Convert.ToInt32($"{Regex.Replace(x, @"\w", xx => xx.Value == "R" || xx.Value == "B" ? "1" : "0")}", 2));
        }

    }
}
