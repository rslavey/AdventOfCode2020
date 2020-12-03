using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace com.randyslavey.AdventOfCode2020
{
    class Day03
    {
        private string[] InputValues { get; set; }

        internal int GetSolution(int part, int xmove = 3, int ymove = 1)
        {
            return part == 1 ?
                InputValues.Select((item, index) => new { item, index }).Count(x => '#' == x.item.ToCharArray()[(x.index / ymove) * xmove % x.item.Length] && x.index % ymove == 0 && x.index > 0) :
                (new List<(int xmove, int ymove)> { (1, 1), (3, 1), (5, 1), (7, 1), (1, 2) }).Select(x => GetSolution(1, x.xmove, x.ymove)).Aggregate(1, (a, v) => a * v);
        }

        internal void GetInputData(string filePath)
        {
            InputValues = File.ReadAllLines(filePath);
        }
    }
}
