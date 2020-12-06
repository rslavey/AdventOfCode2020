using com.randyslavey.AdventOfCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace com.randyslavey.AdventOfCode2020
{
    class Day062020 : IAdventOfCodeGroupedData
    {
        public int Result { get; set; }
        public string[] InputValues { get; set; }
        public IEnumerable<IEnumerable<string>> GroupedInputs { get; set; }

        public string GetSolution(int part)
        {
            Result = part == 1 ?
                GroupedInputs.Sum(x => x.Union().Length) :
                GroupedInputs.Sum(x => x.Intersect().Length);

            return $"{Result}";
        }

        public void GetInputData(string file)
        {
            GroupedInputs = File.ReadAllText(file).Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Select(xx => xx));
        }
    }
}
