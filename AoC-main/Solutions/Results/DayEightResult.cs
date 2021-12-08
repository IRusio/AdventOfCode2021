using System;

namespace AoC_main.Solutions.Results
{
    public class DayEightResult : IResult
    {
        public long Instances { get; set; }
        public void ShowResult()
        {
            Console.WriteLine(Instances);
        }
    }
}