using System;

namespace com.randyslavey.AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            RunCode(2);
            Console.ReadLine();
        }

        private static void RunCode(int dayId)
        {
            switch (dayId)
            {
                case 1:
                    var d1 = new Day01(2020, 3);
                    d1.GetInputData(@".\Inputs\DayOneInput.txt");
                    Console.WriteLine(d1.GetSolution());
                    break;
                case 2:
                    var d2 = new Day02();
                    d2.GetInputData(@".\Inputs\DayTwoInput.txt");
                    Console.WriteLine(d2.GetSolution(1));
                    break;
            }
        }
    }
}
