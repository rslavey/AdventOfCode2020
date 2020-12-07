using com.randyslavey.AdventOfCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace com.randyslavey.AdventOfCode2020
{
    class Day072020 : IAdventOfCodeUngroupedData
    {
        public int Result { get; set; }
        public string[] InputValues { get; set; }
        private List<string> outerBags = new List<string>();
        private int innerBagsCount { get; set; }
        private List<(string bag, List<(int count, string bag)> bags)> bagDefinitions = new List<(string, List<(int count, string bag)>)>();

        public string GetSolution(int part)
        {
            FindOuterBags("shiny gold");
            FindInnerBags("shiny gold");

            Result = part == 1 ?
                outerBags.Distinct().Count() :
                innerBagsCount;

            return $"{Result}";
        }

        private void FindInnerBags(string b, int m = 1)
        {
            foreach (var bag in bagDefinitions.Where(x => x.bag == b).SelectMany(x => x.bags))
            {
                innerBagsCount += bag.count * m;
                FindInnerBags(bag.bag, bag.count * m);
            }
        }

        private void FindOuterBags(string b)
        {
            foreach (var bag in bagDefinitions.Where(x => x.bags.Any(xx => xx.bag == b)))
            {
                outerBags.Add(bag.bag);
                FindOuterBags(bag.bag);
            }
        }

        public void GetInputData(string file)
        {
            var r = new Regex(@"^(.*) bags contain (.*)\.$");

            bagDefinitions =
                File.ReadAllLines(file).Select(x =>
                (
                    r.Match(x).Groups[1].Value,
                    r.Match(x).Groups[2].Value.Split(',')
                    .Select(xx =>
                        Regex.Match(xx.Trim(), @"^(.*) bag[s]?$").Groups[1].Value
                    )
                    .Select(xx =>
                        Regex.Match(xx, @"^([0-9]+) (.*)$")
                    )
                    .Where(xx =>
                        xx.Success
                    )
                    .Select(xx =>
                        (int.Parse(xx.Groups[1].Value), xx.Groups[2].Value)).ToList()
                    )
                ).ToList();
        }
    }
}
