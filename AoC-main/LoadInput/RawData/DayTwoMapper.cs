using CsvHelper.Configuration;

namespace AoC_main.LoadInput.RawData
{
    public class DayTwoMapper : ClassMap<DayTwo>
    {
        public DayTwoMapper()
        {
            Map(m => m.Command).Name("Command");
            Map(m => m.Value).Name("Value");
        }
    }
}