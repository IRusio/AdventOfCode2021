using System;
using System.Collections.Generic;
using System.Linq;
using AoC_main.LoadInput.RawData;
using AoC_main.Solutions.Results;

namespace AoC_main.Solutions
{
    public class DayEightSolution : ISolution<DayEight>
    {
        public IResult SolutionOne(IEnumerable<DayEight> rawData)
        {
            var data = rawData.First();

            var instances = 0;
            
            foreach (var inputData in data.Input)
            {
                foreach (var input in inputData.Output)
                {
                    if (input.Status.Count == 2 || input.Status.Count == 4 || input.Status.Count == 3 ||
                        input.Status.Count == 7)
                        instances++;
                }
            }

            return new DayEightResult() { Instances = instances };
        }

        public IResult SolutionTwo(IEnumerable<DayEight> rawData)
        {
            var data = rawData.First();

            var instances = new List<long>();

            foreach (var inputData in data.Input)
            {
                var number = "";

                var onePredictions = inputData.Input.Single(x => x.Status.Count == 2);
                var sevenPredictions = inputData.Input.Single(x => x.Status.Count == 3);
                var fourPredictions = inputData.Input.Single(x => x.Status.Count == 4);
                var eightPredictions = inputData.Input.Single(x => x.Status.Count == 7);

                var fiveDigitsPredictions = inputData.Input.Where(x => x.Status.Count == 5).ToList();
                var sixDigitsPredictions = inputData.Input.Where(x => x.Status.Count == 6).ToList();
                
                var threePredictions = 
                    fiveDigitsPredictions.First(x => onePredictions.GetKeys.All(x.GetKeys.Contains)
                );
                fiveDigitsPredictions.Remove(threePredictions);

                var ninePredictions = 
                    sixDigitsPredictions.Single(x => threePredictions.GetKeys.All(x.GetKeys.Contains)
                    );

                sixDigitsPredictions.Remove(ninePredictions);
                
                var zeroPredictions = sixDigitsPredictions.Single(
                    x => onePredictions.GetKeys.All(x.GetKeys.Contains)
                    );
                sixDigitsPredictions.Remove(zeroPredictions);

                var sixPrediction = sixDigitsPredictions.Single();

                var fivePrediction = fiveDigitsPredictions.Single(x => x.GetKeys.All(sixPrediction.GetKeys.Contains));

                fiveDigitsPredictions.Remove(fivePrediction);

                var twoPrediction = fiveDigitsPredictions.Single();

                var digitObjects = new List<string>()
                {
                    string.Join("", zeroPredictions.GetKeys.OrderBy(x=>x)),
                    string.Join("",onePredictions.GetKeys.OrderBy(x=>x)), 
                    string.Join("",twoPrediction.GetKeys.OrderBy(x=>x)),
                    string.Join("",threePredictions.GetKeys.OrderBy(x=>x)),
                    string.Join("",fourPredictions.GetKeys.OrderBy(x=>x)),
                    string.Join("",fivePrediction.GetKeys.OrderBy(x=>x)),
                    string.Join("",sixPrediction.GetKeys.OrderBy(x=>x)),
                    string.Join("",sevenPredictions.GetKeys.OrderBy(x=>x)),
                    string.Join("",eightPredictions.GetKeys.OrderBy(x=>x)),
                    string.Join("",ninePredictions.GetKeys.OrderBy(x=>x)),
                };

                foreach (var input in inputData.Output)
                {
                    var testObject = string.Join("", input.GetKeys.OrderBy(x => x));
                    number += digitObjects.IndexOf(testObject);
                }
                
                instances.Add(long.Parse(number));
            }

            return new DayEightResult() { Instances = instances.Sum(x=>x) };
        }
        
    }
}