using System.Collections.Generic;

namespace AoC_main.LoadInput.RawData
{
    public interface IRawMapper<T>
    {
        public T MapObject(IEnumerable<string> input);
    }
}