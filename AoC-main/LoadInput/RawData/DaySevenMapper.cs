using System.Collections.Generic;
using System.Linq;

namespace AoC_main.LoadInput.RawData
{
    public class DaySevenMapper : IRawMapper<DaySeven>
    {
        public DaySeven MapObject(IEnumerable<string> input)
        {
            return new DaySeven() { CrabsPositions = input.First().Split(',').Select(int.Parse) };
        }
    }
}