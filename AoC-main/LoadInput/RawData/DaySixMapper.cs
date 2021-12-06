using System.Collections.Generic;
using System.Linq;

namespace AoC_main.LoadInput.RawData
{
    public class DaySixMapper : IRawMapper<DaySix>
    {
        public DaySix MapObject(IEnumerable<string> input)
        {
            return new DaySix() { DaysTillCreateNewOne = input.First().Split(',').Select(int.Parse) };
        }
    }
}