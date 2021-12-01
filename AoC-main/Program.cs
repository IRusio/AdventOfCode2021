using System;
using System.Collections.Generic;
using AoC_main.LoadInput;
using AoC_main.LoadInput.RawData;
using AoC_main.Solutions;

namespace AoC_main
{
    class Program
    {
        static void Main(string[] args)
        {
            var content = CsvLoader.LoadFile<DayOne>(new DayOneMapper()) as IEnumerable<DayOne>;
            var testContent = CsvLoader.LoadFile<DayOne>(new DayOneMapper(), true) as IEnumerable<DayOne>;
            
            DayOneSolution dayOneSolution = new DayOneSolution();
            var result = dayOneSolution.SolutionOne(content);
            var testResult = dayOneSolution.SolutionOne(testContent);
            result.ShowResult();
            testResult.ShowResult();
            
            result = dayOneSolution.SolutionTwo(content);
            testResult = dayOneSolution.SolutionTwo(testContent);
            result.ShowResult();
            testResult.ShowResult();
            
        }
    }
}