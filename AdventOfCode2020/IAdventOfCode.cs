using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.randyslavey.AdventOfCode
{
    public interface IAdventOfCode
    {
        string GetSolution(int partId);
        void GetInputData(string file);
    }
    public interface IAdventOfCodeGroupedData : IAdventOfCode
    {
        IEnumerable<IEnumerable<string>> GroupedInputs { get; set; }
    }

    public interface IAdventOfCodeUngroupedData : IAdventOfCode
    {
        string[] InputValues { get; set; }
    }

    public interface IAdventOfCodeSingleData : IAdventOfCode
    {
        string InputValue { get; set; }

    }

}
