using com.randyslavey.AdventOfCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace com.randyslavey.AdventOfCode2020
{
    class Day082020 : IAdventOfCodeUngroupedData
    {
        public string[] InputValues { get; set; }
        List<(int index, string op, int num)> FormattedInputs { get; set; }
        HashSet<int> lineTest = new HashSet<int>();
        public string GetSolution(int part)
        {
            int acc = 0;
            var i = -1;
            int line = 0;
            while (line != FormattedInputs.Count())
            {
                lineTest.Clear();
                acc = line = 0;
                while (!lineTest.Any(x => x == line) && line != FormattedInputs.Count())
                {
                    lineTest.Add(line);
                    acc += FormattedInputs[line].op == "acc" ? FormattedInputs[line].num : 0;
                    line += (line == i && FormattedInputs[line].op == "nop") | (line != i && FormattedInputs[line].op == "jmp") ? FormattedInputs[line].num : 1;
                }
                if (part == 1)
                {
                    break;
                }
                i = FormattedInputs.FirstOrDefault(x => x.index > i && (x.op == "nop" || x.op == "jmp")).index;
            }

            return $"{acc}";
        }
        
        public void GetInputData(string file)
        {
            var i = 0;
            FormattedInputs = File.ReadAllLines(file).Select(x => (i++, x.Split(' ')[0], int.Parse(x.Split(' ')[1]))).ToList();
        }
    }
}
