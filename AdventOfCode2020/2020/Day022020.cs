﻿using com.randyslavey.AdventOfCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace com.randyslavey.AdventOfCode2020
{
    class Day022020 : IAdventOfCode
    {
        public int Result { get; set; }
        public string[] InputValues { get; set; }

        private List<(int lowReq, int highReq, char letter, string pass)> SplitInputValues = new List<(int lowReq, int highReq, char letter, string pass)>();

        public string GetSolution(int part)
        {
            Result = part == 1 ?
                SplitInputValues.Count(x => Enumerable.Range(x.lowReq, x.highReq - x.lowReq + 1).Contains(x.pass.ToCharArray().Count(xx => xx == x.letter))) :
                SplitInputValues.Count(x => x.pass[x.lowReq - 1] == x.letter ^ x.pass[x.highReq - 1] == x.letter);

            return $"{Result}";
        }

        public void GetInputData(string filePath)
        {
            InputValues = File.ReadAllLines(filePath);
            foreach (var line in InputValues)
            {
                SplitInputValues.Add(
                    (
                        int.Parse(line.Split(' ')[0].Split('-')[0]),
                        int.Parse(line.Split(' ')[0].Split('-')[1]),
                        line.Split(' ')[1].ToCharArray()[0],
                        line.Split(' ')[2]
                    )
                );
            }
        }
    }
}
