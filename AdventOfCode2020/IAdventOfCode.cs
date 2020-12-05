using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.randyslavey.AdventOfCode
{
    public interface IAdventOfCode
    {
        string[] InputValues { get; set; }
        void GetInputData(string file);
        string GetSolution(int partId);
    }
}
