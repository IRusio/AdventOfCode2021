using System;
using System.Collections.Generic;
using System.Linq;
using AoC_main.LoadInput.RawData;
using AoC_main.Solutions.Results;

namespace AoC_main.Solutions
{
    public class DaySixSolution : ISolution<DaySix>
    {
        public IResult SolutionOne(IEnumerable<DaySix> rawData)
        {
            var data = 
                rawData
                    .First()
                    .DaysTillCreateNewOne
                    .Select(x=>x)
                    .GroupBy(x => x)
                    .OrderBy(x=>x.Key)
                    .Select(x=>x.Count()).ToList();

            
            //be sure that there will 8 days available;
            data.Insert(0, 0);
            while (data.Count() < 9)
                data.Add(0);
            
            for (long i = 0; i < 80; i++)
            {
                var nextDayFishes = new List<int>(){0,0,0,0,0,0,0,0,0};
                for (int fishDay = 8; fishDay >= 0; fishDay--)
                {
                    if (fishDay == 0)
                    {
                        nextDayFishes[6] += data[0];
                        nextDayFishes[8] += data[0];
                    }
                    else nextDayFishes[fishDay - 1] += data[fishDay];

                }

                data = nextDayFishes;
                Console.WriteLine(data.Sum(x=>x));
            }
            
            int sum = 0;

            foreach (var element in data)
            {
                sum += element;
            }
            return new DaySixResult() { Result = ulong.Parse(sum.ToString()) };
        }

        public IResult SolutionTwo(IEnumerable<DaySix> rawData)
        {
            var data = 
                rawData
                    .First()
                    .DaysTillCreateNewOne
                    .Select(x=>x)
                    .GroupBy(x => x)
                    .OrderBy(x=>x.Key)
                    .Select(x=>x.Count()).Select(x=> ulong.Parse(x.ToString())).ToList();

            
            //be sure that there will 8 days available;
            data.Insert(0, 0);
            while (data.Count() < 9)
                data.Add(0);
            
            for (long i = 0; i < 256; i++)
            {
                var nextDayFishes = new List<ulong>(){0,0,0,0,0,0,0,0,0};
                for (int fishDay = 8; fishDay >= 0; fishDay--)
                {
                    if (fishDay == 0)
                    {
                        nextDayFishes[6] += data[0];
                        nextDayFishes[8] += data[0];
                    }
                    else nextDayFishes[fishDay - 1] += data[fishDay];

                }

                data = nextDayFishes;
            }

            ulong sum = 0;

            foreach (var element in data)
            {
                sum += element;
            }
            return new DaySixResult() { Result = sum };
        }
    }
}