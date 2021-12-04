using System;

namespace AoC_main.Solutions.Results
{
    public class DayThreeResult : IResult
    {
        public int Result { get; set; }
        public void ShowResult()
        {
            Console.WriteLine(Result);
        }
    }
}