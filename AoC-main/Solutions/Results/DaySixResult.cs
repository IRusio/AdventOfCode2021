using System;

namespace AoC_main.Solutions.Results
{
    public class DaySixResult : IResult
    {
        public ulong Result { get; set; }
        
        public void ShowResult()
        {
            Console.WriteLine($"count of fish after 80 days: {Result}");
        }
    }
}