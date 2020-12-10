using com.randyslavey.AdventOfCode;
using Combinatorics.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace com.randyslavey.AdventOfCode2020
{
    class Day092020 : IAdventOfCodeUngroupedData
    {
        public long Result { get; set; }

        public string[] InputValues { get; set; }
        public List<(int index, long value)> FormattedInputValues { get; set; }

        public string GetSolution(int part)
        {
            var first = Enumerable.Range(0, FormattedInputValues.Count()).FirstOrDefault(x =>
                new Combinations<long>(FormattedInputValues.Select(xx => xx.value).Skip(x).Take(25).ToList(), 2).Count(xx => xx.Sum() == FormattedInputValues[25 + x].value) == 0
            );

            Result = part == 1 ?
                FormattedInputValues[first + 25].value :
                Enumerable.Range(0, first + 25).Select(x => new
                {
                    startIndex = x,
                    nextIndex = Enumerable.Range(x + 1, first + 25).FirstOrDefault(xx =>
                          FormattedInputValues.Where(xxx =>
                              xxx.index >= x && xxx.index < xx
                          ).Sum(xxx => xxx.value) == FormattedInputValues[first + 25].value
                                  )
                }
                )
                .Where(x =>
                    x.nextIndex != 0
                )
                .Select(x =>
                    FormattedInputValues.Where(xx =>
                        xx.index >= x.startIndex && xx.index <= x.nextIndex
                    ).Min(xx => xx.value) +
                    FormattedInputValues.Where(xx =>
                        xx.index >= x.startIndex && xx.index <= x.nextIndex
                    ).Max(xx => xx.value)
                ).FirstOrDefault();

            return $"{Result}";
        }

        public void GetInputData(string file)
        {
            InputValues = File.ReadAllLines(file);
            FormattedInputValues = File.ReadAllLines(file).Select((value, index) => (value, index)).Select(x => (x.index, long.Parse(x.value))).ToList();
        }
    }
}
