using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace com.randyslavey.AdventOfCode2020
{
    class Day02
    {
        private List<(int lowReq, int highReq, char letter, string pass)> InputValues = new List<(int lowReq, int highReq, char letter, string pass)>();

        internal string GetSolution(int part)
        {
            return part == 1 ? 
                InputValues.Where(x => x.pass.ToCharArray().Count(xx => xx == x.letter) >= x.lowReq && x.pass.ToCharArray().Count(xx => xx == x.letter) <= x.highReq).Count().ToString() : 
                InputValues.Where(x => x.pass[x.lowReq - 1] == x.letter ^ x.pass[x.highReq - 1] == x.letter).Count().ToString();
        }

        internal void GetInputData(string filePath)
        {
            foreach (var line in File.ReadAllLines(filePath))
            {
                InputValues.Add(
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
