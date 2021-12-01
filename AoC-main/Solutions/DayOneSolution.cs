using System.Collections.Generic;
using System.Linq;
using AoC_main.LoadInput;
using AoC_main.LoadInput.RawData;
using AoC_main.Solutions.Results;

namespace AoC_main.Solutions
{
    public class DayOneSolution : ISolution<DayOne>
    {
        public IResult SolutionOne(IEnumerable<DayOne> rawData)
        {
            var deeperCount = 0;
            var lastRecord = rawData.First();

            foreach (var data in rawData.Skip(1))
            {
                if (lastRecord.Depth < data.Depth)
                {
                    deeperCount += 1;
                    lastRecord = data;
                }
                else lastRecord = data;
            }

            return new DayOneResult() { Difference = deeperCount };
        }

        public IResult SolutionTwo(IEnumerable<DayOne> rawData)
        {
            var deeperCount = 0;
            var measurement = new Queue<int>(rawData.Take(3).Select(x=>x.Depth));
            var lastSum = measurement.Sum();

            foreach (var dayOne in rawData)
            {
                if (measurement.Count == 3)
                    measurement.Dequeue();
                measurement.Enqueue(dayOne.Depth);
                if (lastSum < measurement.Sum(x => x))
                {
                    deeperCount += 1;
                }

                lastSum = measurement.Sum();
            }

            return new DayOneResult() { Difference = deeperCount };
        }
    }
}