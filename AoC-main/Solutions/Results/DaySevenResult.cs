using System;
using AoC_main.LoadInput.RawData;

namespace AoC_main.Solutions.Results
{
    public class DaySevenResult : IResult
    {
        public int Fuel { get; set; }
        
        public void ShowResult()
        {
            Console.WriteLine($"required fuel: {Fuel}");
        }
    }
}