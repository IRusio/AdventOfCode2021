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
            var dayThreeData = rawData as DayThree[] ?? rawData.ToArray();
            
            var oxygenFilter = dayThreeData;
            var oxygenItt = 0;

            while (oxygenFilter.Length > 1)
            {
                var dominant = CalculateDominantValue(oxygenFilter.Select(x => x.Bites), oxygenItt);

                if (dominant.zero <= dominant.one)
                {
                    oxygenFilter = oxygenFilter.Where(x => x.Bites[oxygenItt] == '1').ToArray();
                }
                else
                {
                    oxygenFilter = oxygenFilter.Where(x => x.Bites[oxygenItt] == '0').ToArray();
                }
                
                oxygenItt += 1;
            }
            
            
            var coTwoFilter = dayThreeData;
            var coTwoItt = 0;

            while (coTwoFilter.Length > 1)
            {
                var dominant = CalculateDominantValue(coTwoFilter.Select(x => x.Bites), coTwoItt);

                if (dominant.zero > dominant.one)
                {
                    coTwoFilter = coTwoFilter.Where(x => x.Bites[coTwoItt] == '1').ToArray();
                }
                else
                {
                    coTwoFilter = coTwoFilter.Where(x => x.Bites[coTwoItt] == '0').ToArray();
                }
                
                coTwoItt += 1;
            }
            
            
            var gamma = Convert.ToInt32(oxygenFilter.First().Bites, 2);
            var epsilon = Convert.ToInt32(coTwoFilter.First().Bites, 2);
            
            return new DayThreeResult(){Result = gamma * epsilon};
            return null;
        }

        public (int zero, int one) CalculateDominantValue(IEnumerable<string> data, int columnId)
        {
            var oneCount = 0;
            var zeroCount = 0;  
            foreach (var obj in data)
            {
                if (obj[columnId] == '0')
                    zeroCount += 1;
                else oneCount += 1;
            }

            return (zeroCount, oneCount);
        }
    }
}