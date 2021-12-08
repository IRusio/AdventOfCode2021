using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC_main.LoadInput.RawData
{
    public class DayEightMapper : IRawMapper<DayEight>
    {
        public DayEight MapObject(IEnumerable<string> input)
        {
            var resultCollection = new List<DayEightData>();
            foreach (var line in input)
            {
                var splitInput = line.Split('|');

                var newDay = new DayEightData();
                
                foreach (var front in splitInput.First().Split(" ", StringSplitOptions.RemoveEmptyEntries))
                {
                    newDay.Input.Add(new DigitObject(front));
                }
                
                foreach (var front in splitInput.Last().Split(" ", StringSplitOptions.RemoveEmptyEntries))
                {
                    newDay.Output.Add(new DigitObject(front));
                }
                
                resultCollection.Add(newDay);
            }

            return new DayEight() { Input = resultCollection };
        }
    }
}