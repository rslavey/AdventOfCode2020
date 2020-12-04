using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace com.randyslavey.AdventOfCode2020
{
    class Day04
    {
        private List<Dictionary<string, string>> InputValues = new List<Dictionary<string, string>>();

        internal int GetSolution(int part)
        {
            return part == 1 ?
                InputValues.Count(x => ValidateBatch(x)) :
                InputValues.Count(x => ValidateBatch(x) && ValidateValues(x));
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

            var rhcl = new Regex("^#(?:[0-9a-fA-F]{3}){1,2}$");
            if (!rhcl.IsMatch(d["hcl"]))
            {
                return false;
            }

            var recl = new Regex("^(?:amb|blu|brn|gry|grn|hzl|oth)$");
            if (!recl.IsMatch(d["ecl"]))
            {
                return false;
            }

            var rpid = new Regex("^(?:[0-9]{9})$");
            if (!rpid.IsMatch(d["pid"]))
            {
                return false;
            }
            return true;
        }

        private bool ValidateBatch(Dictionary<string, string> x)
        {
            return x.ContainsKey("byr") && x.ContainsKey("iyr") && x.ContainsKey("eyr") && x.ContainsKey("hgt") && x.ContainsKey("hcl") && x.ContainsKey("ecl") && x.ContainsKey("pid");
        }

        internal void GetInputData(string filePath)
        {
            var curBatch = new Dictionary<string,string>();
            var inputs = new List<Dictionary<string, string>>();
            foreach(var line in File.ReadAllLines(filePath))
            {
                if (line != string.Empty)
                {
                    line.Split(' ').ToList().ForEach(x => curBatch.Add(x.Split(':')[0], x.Split(':')[1]));
                }
                else
                {
                    InputValues.Add(curBatch.ToDictionary(entry => entry.Key, entry => entry.Value));
                    curBatch.Clear();
                }
            }
            InputValues.Add(curBatch);
        }
    }
}
