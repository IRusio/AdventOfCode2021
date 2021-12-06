using CsvHelper.Configuration;

namespace AoC_main.LoadInput.RawData
{
    public class DayFiveMapper : ClassMap<DayFive>
    {
        public DayFiveMapper()
        {
            Map(x => x.From).Name("From");
            Map(x => x.To).Name("To");  
        }
    }
}