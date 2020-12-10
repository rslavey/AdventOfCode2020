using com.randyslavey.AdventOfCode;
using Combinatorics.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace com.randyslavey.AdventOfCode2020
{
    class Day102020 : IAdventOfCodeUngroupedData
    {
        public long Result { get; set; }

        public string[] InputValues { get; set; }
        public string GetSolution(int part)
        {
            var formattedInput = InputValues.Select(x => int.Parse(x)).OrderBy(x => x).ToArray();
            formattedInput = formattedInput.Prepend(0).ToArray();

            if (part == 1)
            {
                Dictionary<int, int> jolts = new Dictionary<int, int>() { { 1, 0 }, { 2, 0 }, { 3, 0 } };
                for (var i = 0; i < formattedInput.Count() - 1; i++)
                {
                    jolts[formattedInput[i + 1] - formattedInput[i]]++;
                }
                jolts[3]++;
                Result = jolts[3] * jolts[1];
            }
            else
            {
                long combos = 1;
                var gs = 0;
                for (var i = 0; i < formattedInput.Count() - 1; i++)
                {
                    gs++;
                    if (formattedInput[i + 1] - formattedInput[i] == 3)
                    {
                        combos *= (gs == 5 ? 7 : gs == 4 ? 4 : gs == 3 ? 2 : 1);
                        gs = 0;
                    }
                }
                Result = combos;
            }

            return $"{Result}";
        }

        public void GetInputData(string file)
        {
            InputValues = File.ReadAllLines(file);
        }
    }
}
