using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace com.randyslavey.AdventOfCode2020
{
    class Day01
    {
        public int TargetSum { get; set; }
        public int NumCount { get; set; }
        List<int> InputValues = new List<int>();

        public Day01(int targetSum, int numCount)
        {
            TargetSum = targetSum;
            NumCount = numCount;
        }

        internal string GetSolution()
        {
            return $"{Helpers.FindSum(InputValues.ToArray(), new int[NumCount], 0, InputValues.ToArray().Length - 1, 0, NumCount, TargetSum).Aggregate(1, (acc, val) => acc * val)}";
        }

        internal void GetInputData(string filePath)
        {
            InputValues.AddRange(File.ReadAllLines(filePath).Select(x => int.Parse(x)));
        }
    }
}
