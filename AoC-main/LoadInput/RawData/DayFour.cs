using System.Collections.Generic;

namespace AoC_main.LoadInput.RawData
{
    public class DayFour : IRawData
    {
        public IEnumerable<int> WinningNumbers;
        public List<DayFourBoardPoint[][]> GameBoards = new();
    }

    public class DayFourBoardPoint
    {
        public int Value;
        public bool IsChecked = false;
    }
}