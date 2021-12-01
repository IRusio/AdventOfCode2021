using System.Collections.Generic;
using AoC_main.LoadInput;

namespace AoC_main.Solutions
{
    public interface ISolution<T>
    {
        IResult SolutionOne(IEnumerable<T> rawData);
        IResult SolutionTwo(IEnumerable<T> rawData);
    }
}