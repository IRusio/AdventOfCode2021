using System;

namespace AoC_main.Solutions.Results
{
    public class DayOneResult : IResult
    {
        public int Difference;

        public void ShowResult()
        {
            Console.WriteLine($"Day One Task One result: {Difference}");
        }
    }
}