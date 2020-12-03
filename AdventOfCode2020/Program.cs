using System;

namespace com.randyslavey.AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            RunCode(2,1);
            Console.ReadLine();
        }

        private static void RunCode(int dayId, int partId = 1)
        {
            switch (dayId)
            {
                case 1:
                    var d1 = new Day01();
                    d1.GetInputData(@".\Inputs\Day01Input.txt");
                    Console.WriteLine(d1.GetSolution(2020, 3));
                    break;
                case 2:
                    var d2 = new Day02();
                    d2.GetInputData(@".\Inputs\Day02Input.txt");
                    Console.WriteLine(d2.GetSolution(partId));
                    break;
                case 3:
                    var d3 = new Day03();
                    d3.GetInputData(@".\Inputs\Day03Input.txt");
                    Console.WriteLine(d3.GetSolution(partId));
                    break;
            }
        }
    }
}
