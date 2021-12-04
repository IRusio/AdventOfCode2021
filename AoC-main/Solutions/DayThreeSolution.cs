using System;
using System.Collections.Generic;
using System.Linq;
using AoC_main.LoadInput.RawData;
using AoC_main.Solutions.Results;

namespace AoC_main.Solutions
{
    public class DayThreeSolution : ISolution<DayThree>
    {
        public IResult SolutionOne(IEnumerable<DayThree> rawData)
        {
            var dayThreeData = rawData as DayThree[] ?? rawData.ToArray();

            var countOfZeros = new List<int>();

            foreach (var itt in dayThreeData[0].Bites)
            {
                countOfZeros.Add(0);
            }

            foreach (var line in dayThreeData)
            {
                foreach (var (bit, itt) in line.Bites.Select((sign, itt) => (sign, itt)))
                {
                    if (bit == '0')
                        countOfZeros[itt] += 1;
                }
            }

            var rawBitesResult = "";
            var reversedBitesResult = "";

            var countOfRecords = dayThreeData.Length;
            
            foreach (var countOfZero in countOfZeros)
            {
                if (countOfRecords / 2 < countOfZero)
                {
                    rawBitesResult += 0;
                    reversedBitesResult+=(1);
                }
                else
                {
                    rawBitesResult += 1;
                    reversedBitesResult += (0);
                }
            }

            var gamma = Convert.ToInt32(rawBitesResult, 2);
            var epsilon = Convert.ToInt32(reversedBitesResult, 2);

            return new DayThreeResult(){Result = gamma * epsilon};
        }

        public IResult SolutionTwo(IEnumerable<DayThree> rawData)
        {
            // var dayThreeData = rawData as DayThree[] ?? rawData.ToArray();
            //
            // var resultFilter = dayThreeData;
            //
            // foreach (var line in dayThreeData)
            // {
            //     foreach (var (bit, itt) in line.Bites.Select((sign, itt) => (sign, itt)))
            //     {
            //         if (bit == '0')
            //             countOfZeros[itt] += 1;
            //     }
            // }
            //
            // var rawBitesResult = "";
            // var reversedBitesResult = "";
            //
            // var countOfRecords = dayThreeData.Length;
            //
            // foreach (var countOfZero in countOfZeros)
            // {
            //     if (countOfRecords / 2 < countOfZero)
            //     {
            //         rawBitesResult += 0;
            //         reversedBitesResult+=(1);
            //     }
            //     else
            //     {
            //         rawBitesResult += 1;
            //         reversedBitesResult += (0);
            //     }
            // }
            //
            // var gamma = Convert.ToInt32(rawBitesResult, 2);
            // var epsilon = Convert.ToInt32(reversedBitesResult, 2);
            //
            // return new DayThreeResult(){Result = gamma * epsilon};
            return null;
        }

        public int CalculateDominantValue()
        {
            return 0;
        }
    }
}