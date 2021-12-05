using System.Collections.Generic;

namespace AoC_main.LoadInput.RawData
{
    public class DayFour : IRawData
    {
        public IEnumerable<int> WinningNumbers { get; set; }
        public List<DayFourBoardPoint[][]> GameBoards { get; set; }= new();
    }

    public class DayFourBoardPoint
    {
        public int Value;
        public bool IsChecked = false;
    }
}