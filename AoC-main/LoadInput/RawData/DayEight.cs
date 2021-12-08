using System.Collections.Generic;
using System.Linq;

namespace AoC_main.LoadInput.RawData
{
    public class DayEight : IRawData
    {
        public IEnumerable<DayEightData> Input;
    }

    public class DayEightData
    {
        public List<DigitObject> Input;
        public List<DigitObject> Output;

        public DayEightData()
        {
            Input = new List<DigitObject>();
            Output = new List<DigitObject>();
        }
    }

    public class DigitObject
    {
        public Dictionary<string, bool> Status;

        public IEnumerable<string> GetKeys => Status.Select(x => x.Key).ToList();
        
        public DigitObject(string content)
        {
            Status = new Dictionary<string, bool>();
            foreach (var element in content)
            {
                Status.Add(element.ToString(), true);
            }
        }
    }
}