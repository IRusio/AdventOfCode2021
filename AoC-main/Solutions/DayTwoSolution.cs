using System;
using System.Collections.Generic;
using AoC_main.LoadInput.RawData;
using AoC_main.Solutions.Results;

namespace AoC_main.Solutions
{
    public class DayTwoSolution : ISolution<DayTwo>
    {
        public IResult SolutionOne(IEnumerable<DayTwo> rawData)
        {
            var position = (distance: 0,depth: 0);

            foreach (var positionUpdate in rawData)
            {
                switch (positionUpdate.Command)
                {
                    case "forward":
                        position.distance += positionUpdate.Value;
                        break;
                    case "down":
                        position.depth += positionUpdate.Value;
                        break;
                    case "up":
                        position.depth -= positionUpdate.Value;
                        break;
                    default:
                        throw new Exception("not found value");
                }
            }

            return new DayTwoResult() { Depth = position.depth, Horizontal = position.distance };
        }

        public IResult SolutionTwo(IEnumerable<DayTwo> rawData)
        {
            var position = (distance: 0,depth: 0, aim: 0);

            foreach (var positionUpdate in rawData)
            {
                switch (positionUpdate.Command)
                {
                    case "forward":
                        position.distance += positionUpdate.Value;
                        position.depth += positionUpdate.Value * position.aim;
                        break;
                    case "down":
                        position.aim += positionUpdate.Value;
                        break;
                    case "up":
                        position.aim -= positionUpdate.Value;
                        break;
                    default:
                        throw new Exception("not found value");
                }
            }

            return new DayTwoResult() { Depth = position.depth, Horizontal = position.distance };
        }
    }
}