using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace com.randyslavey.AdventOfCode2020
{
    class Day02
    {
        private List<(int lowReq, int highReq, char letter, string pass)> InputValues = new List<(int lowReq, int highReq, char letter, string pass)>();

        internal int GetSolution(int part)
        {
            return part == 1 ? 
                InputValues.Count(x => Enumerable.Range(x.lowReq, x.highReq - x.lowReq + 1).Contains(x.pass.ToCharArray().Count(xx => xx == x.letter))) : 
                InputValues.Count(x => x.pass[x.lowReq - 1] == x.letter ^ x.pass[x.highReq - 1] == x.letter);
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
