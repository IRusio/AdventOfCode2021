using CsvHelper.Configuration;

namespace AoC_main.LoadInput.RawData
{
    public sealed class DayOneMapper: ClassMap<DayOne>
    {
        public DayOneMapper()
        {
            Map(m => m.Depth).Name("Depth");
        }
    }
}