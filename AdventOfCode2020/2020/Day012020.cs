﻿using com.randyslavey.AdventOfCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace com.randyslavey.AdventOfCode2020
{
    class Day012020 : IAdventOfCodeUngroupedData
    {
        public int Result { get; set; }
        public string[] InputValues { get; set; }

        public string GetSolution(int partId)
        {
            Result = partId == 1 ?
                Helpers.FindSum(InputValues.Select(x => int.Parse(x)).ToArray(), new int[2], 0, InputValues.ToArray().Length - 1, 0, 2, 2020).Aggregate(1, (acc, val) => acc * val) :
                Helpers.FindSum(InputValues.Select(x => int.Parse(x)).ToArray(), new int[3], 0, InputValues.ToArray().Length - 1, 0, 3, 2020).Aggregate(1, (acc, val) => acc * val);

            return $"{Result}";
        }

        public void GetInputData(string file)
        {
            InputValues = File.ReadAllLines(file);
        }
    }
}
