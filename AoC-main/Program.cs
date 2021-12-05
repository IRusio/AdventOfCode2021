using System;
using System.Collections.Generic;
using System.Linq;
using AoC_main.LoadInput;
using AoC_main.LoadInput.RawData;
using AoC_main.Solutions;

namespace AoC_main
{
    class Program
    {
        static void Main(string[] args)
        {
            // var content = CsvLoader.LoadFile<DayOne>(new DayOneMapper()) as IEnumerable<DayOne>;
            // var testContent = CsvLoader.LoadFile<DayOne>(new DayOneMapper(), true) as IEnumerable<DayOne>;
            //
            // DayOneSolution dayOneSolution = new DayOneSolution();
            // var result = dayOneSolution.SolutionOne(content);
            // var testResult = dayOneSolution.SolutionOne(testContent);
            // result.ShowResult();
            // testResult.ShowResult();
            //
            // result = dayOneSolution.SolutionTwo(content);
            // testResult = dayOneSolution.SolutionTwo(testContent);
            // result.ShowResult();
            // testResult.ShowResult();
            
            // var content = CsvLoader.LoadFile<DayTwo>(new DayTwoMapper()) as IEnumerable<DayTwo>;
            // var testContent = CsvLoader.LoadFile<DayTwo>(new DayTwoMapper(), true) as IEnumerable<DayTwo>;
            //
            // var daySolution = new DayTwoSolution();
            // var result = daySolution.SolutionOne(content);
            // var testResult = daySolution.SolutionOne(testContent);
            // result.ShowResult();
            // testResult.ShowResult();
            //
            // result = daySolution.SolutionTwo(content);
            // testResult = daySolution.SolutionTwo(testContent);
            // result.ShowResult();
            // testResult.ShowResult();
            //
            //
            // var content = CsvLoader.LoadFile<DayThree>(new DayThreeMapper()) as IEnumerable<DayThree>;
            // var testContent = CsvLoader.LoadFile<DayThree>(new DayThreeMapper(), true) as IEnumerable<DayThree>;
            //
            // var daySolution = new DayThreeSolution();
            // var result = daySolution.SolutionOne(content);
            // var testResult = daySolution.SolutionOne(testContent);
            // result.ShowResult();
            // testResult.ShowResult();
            //
            // result = daySolution.SolutionTwo(content);
            // testResult = daySolution.SolutionTwo(testContent);
            // result.ShowResult();
            // testResult.ShowResult();

            var content = RawStringLoader.LoadFile<DayFour>(new DayFourMapper());
            var testContent = RawStringLoader.LoadFile<DayFour>(new DayFourMapper(), true);
            
            var daySolution = new DayFourSolution();
            var result = daySolution.SolutionOne(content.Select(x=>x as DayFour));
            var testResult = daySolution.SolutionOne(testContent.Select(x=>x as DayFour));
            result.ShowResult();
            testResult.ShowResult();
            
            result = daySolution.SolutionTwo(content.Select(x=>x as DayFour));
            testResult = daySolution.SolutionTwo(testContent.Select(x=>x as DayFour));
            result.ShowResult();
            testResult.ShowResult();
            
        }
    }
}