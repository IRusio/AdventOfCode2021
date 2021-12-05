using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC_main.LoadInput.RawData
{
    public class DayFourMapper : IRawMapper<DayFour>
    {
        public DayFour MapObject(IEnumerable<string> input)
        {
            var resultObject = new DayFour();
            var content = input.ToList();
            resultObject.WinningNumbers = content.First().Split(',').Select(int.Parse).ToList();

            for (var bingoGame = 2; bingoGame < content.Count(); bingoGame+=6)
            {
                var bingoBoard = new DayFourBoardPoint[5][];
                for (int bingoLine = bingoGame, index = 0; bingoLine < bingoGame+5; bingoLine++, index++)
                {
                    if(content[bingoLine] != "")
                        bingoBoard[index] = content[bingoLine]
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .Select(x => new DayFourBoardPoint() { Value = x })
                            .ToArray();
                }

                resultObject.GameBoards.Add(bingoBoard);
            }

            return resultObject;
        }
    }
}