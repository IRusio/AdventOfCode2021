using System;

namespace AoC_main.Solutions.Results
{
    public class DayTwoResult : IResult
    {
        public int Horizontal { get; set; }
        public int Depth { get; set; }
        
        public void ShowResult()
        {
            Console.WriteLine($"Horizontal: {Horizontal}, Depth: {Depth}, horizontalPosition: {Horizontal*Depth}");
        }
    }
}