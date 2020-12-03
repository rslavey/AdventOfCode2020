using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace com.randyslavey.AdventOfCode2020
{
    class Day01
    {
        List<int> InputValues = new List<int>();

        internal string GetSolution(int numCount, int targetSum)
        {
            return $"{Helpers.FindSum(InputValues.ToArray(), new int[numCount], 0, InputValues.ToArray().Length - 1, 0, numCount, targetSum).Aggregate(1, (acc, val) => acc * val)}";
        }

        internal void GetInputData(string filePath)
        {
            InputValues.AddRange(File.ReadAllLines(filePath).Select(x => int.Parse(x)));
        }
    }
}
