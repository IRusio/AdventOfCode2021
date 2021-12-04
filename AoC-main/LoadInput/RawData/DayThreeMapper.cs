using CsvHelper.Configuration;

namespace AoC_main.LoadInput.RawData
{
    public class DayThreeMapper : ClassMap<DayThree>
    {
        public DayThreeMapper()
        {
            Map(m => m.Bites).Name("Bites");
        }
    }
}