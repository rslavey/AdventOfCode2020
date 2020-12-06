using com.randyslavey.AdventOfCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace com.randyslavey.AdventOfCode2020
{
    class Day042020 : IAdventOfCodeGroupedData
    {
        public int Result { get; set; }
        public IEnumerable<IEnumerable<string>> GroupedInputs { get; set; }

        public string GetSolution(int part)
        {
            Result = part == 1 ?
                GroupedInputs.Select(x => x.SelectMany(xx => xx.Split(' ')).Select(xx => new KeyValuePair<string, string>(xx.Split(':')[0], xx.Split(':')[1])).ToDictionary(xxx => xxx.Key, xxx => xxx.Value)).Count(x => ValidateBatch(x)) :
                GroupedInputs.Select(x => x.SelectMany(xx => xx.Split(' ')).Select(xx => new KeyValuePair<string, string>(xx.Split(':')[0], xx.Split(':')[1])).ToDictionary(xxx => xxx.Key, xxx => xxx.Value)).Count(x => ValidateBatch(x) && ValidateValues(x));

            return $"{Result}";
        }

        private bool ValidateValues(Dictionary<string, string> d)
        {
            var ryr = new Regex("^([0-9]{4})$");
            if (!ryr.IsMatch(d["byr"]))
            {
                return false;
            }
            else
            {
                var m = ryr.Match(d["byr"]);
                int intByr = 0;
                if (int.TryParse(m.Value, out intByr))
                {
                    if (intByr < 1920 || intByr > 2002)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            if (!ryr.IsMatch(d["iyr"]))
            {
                return false;
            }
            else
            {
                var m = ryr.Match(d["iyr"]);
                int intByr = 0;
                if (int.TryParse(m.Value, out intByr))
                {
                    if (intByr < 2010 || intByr > 2020)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            if (!ryr.IsMatch(d["eyr"]))
            {
                return false;
            }
            else
            {
                var m = ryr.Match(d["eyr"]);
                int intByr = 0;
                if (int.TryParse(m.Value, out intByr))
                {
                    if (intByr < 2020 || intByr > 2030)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            var rhgt = new Regex("^([0-9]+)(cm|in)$");
            if (rhgt.IsMatch(d["hgt"]))
            {
                var m = rhgt.Match(d["hgt"]);
                var hgtVal = int.Parse(m.Groups[1].Value);
                var hgtUnit = m.Groups[2].Value;
                if ((hgtUnit == "cm" && (hgtVal < 150 || hgtVal > 193)) || (hgtUnit == "in" && (hgtVal < 59 || hgtVal > 76)))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            if (!Regex.IsMatch(d["hcl"], "^#(?:[0-9a-fA-F]{3}){1,2}$"))
            {
                return false;
            }

            var recl = new Regex("^(?:amb|blu|brn|gry|grn|hzl|oth)$");
            if (!recl.IsMatch(d["ecl"]))
            {
                return false;
            }

            if (!Regex.IsMatch(d["pid"],"^(?:[0-9]{9})$"))
            {
                return false;
            }
            return true;
        }

        private bool ValidateBatch(Dictionary<string, string> x)
        {
            return x.ContainsKey("byr") && x.ContainsKey("iyr") && x.ContainsKey("eyr") && x.ContainsKey("hgt") && x.ContainsKey("hcl") && x.ContainsKey("ecl") && x.ContainsKey("pid");
        }

        public void GetInputData(string file)
        {
            GroupedInputs = File.ReadAllText(file).Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Select(xx => xx));
        }
    }
}
