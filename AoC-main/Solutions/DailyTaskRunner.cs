using System;
using System.Collections.Generic;
using System.Linq;
using AoC_main.LoadInput;
using AoC_main.LoadInput.RawData;
using CsvHelper.Configuration;

namespace AoC_main.Solutions
{
    public class DailyTaskRunner<T, Solution> where T : IRawData where Solution : ISolution<T>
    {
        public IEnumerable<T> Content { get; set; }
        public IEnumerable<T> TestContent { get; set; }
        public Solution DaySolution { get; set; }

        public DailyTaskRunner(IRawMapper<T> mapper, Solution solution)
        {
            DaySolution = solution;
            Content = RawStringLoader.LoadFile(mapper).Select(x=>(T)x);
            TestContent = RawStringLoader.LoadFile(mapper, true).Select(x=>(T)x);
        }

        public DailyTaskRunner(ClassMap<T> mapper, Solution solution)
        {
            DaySolution = solution;
            Content = (IEnumerable<T>)CsvLoader.LoadFile(mapper);
            TestContent = (IEnumerable<T>)CsvLoader.LoadFile(mapper, true);
        }

        public void RunDailyTask()
        {
            Console.WriteLine(typeof(T).Name);
            
            var result = DaySolution.SolutionOne(Content);
            var testResult = DaySolution.SolutionOne(TestContent);
            result.ShowResult();
            testResult.ShowResult();
            
            result = DaySolution.SolutionTwo(Content);
            testResult = DaySolution.SolutionTwo(TestContent);
            result.ShowResult();
            testResult.ShowResult();
            
        }

    }
}