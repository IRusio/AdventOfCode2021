using System;
using System.Collections.Generic;
using System.Linq;
using AoC_main.LoadInput.RawData;
using AoC_main.Solutions.Results;

namespace AoC_main.Solutions
{
    public class DaySevenSolution : ISolution<DaySeven>
    {
        public IResult SolutionOne(IEnumerable<DaySeven> rawData)
        {
            var crabsPositions = rawData.First().CrabsPositions.ToList();

            var fuelCosts = new List<int>();
            for (int i = crabsPositions.Min(); i < crabsPositions.Max(); i++)
            {
                var fuelCost = 0;
                for (int j = 0; j < crabsPositions.Count(); j++)
                {
                    fuelCost += Math.Abs(i - crabsPositions[j]);
                }
                fuelCosts.Add(fuelCost);
            }
            
            return new DaySevenResult()
                { Fuel = fuelCosts.Min() };
        }

        public IResult SolutionTwo(IEnumerable<DaySeven> rawData)
        {
            var crabsPositions = rawData.First().CrabsPositions.ToList();

            var fuelCosts = new List<int>();
            for (int i = crabsPositions.Min(); i < crabsPositions.Max(); i++)
            {
                var fuelCost = 0;
                for (int j = 0; j < crabsPositions.Count(); j++)
                {
                    fuelCost += CalculateCost(Math.Abs(i - crabsPositions[j]));
                }
                fuelCosts.Add(fuelCost);
            }
            
            return new DaySevenResult()
                { Fuel = fuelCosts.Min() };
        }

        public int CalculateCost(int difference)
        {
            var fuelCost = 0;
            for (int i = 1; i <= difference; i++)
            {
                fuelCost += i;
            }

            return fuelCost;
        }
    }
}