using System;

namespace com.randyslavey.AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            RunCode(1,1);
            Console.ReadLine();
        }

        private static void RunCode(int dayId, int partId = 1)
        {
            switch (dayId)
            {
                case 1:
                    var d1 = new Day01(2020, 3);
                    d1.GetInputData(@".\Inputs\Day01Input.txt");
                    Console.WriteLine(d1.GetSolution());
                    break;
                case 2:
                    var d2 = new Day02();
                    d2.GetInputData(@".\Inputs\Day02Input.txt");
                    Console.WriteLine(d2.GetSolution(partId));
                    break;
            }
        }
    }
}
