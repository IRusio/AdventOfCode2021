using System.Collections.Generic;
using System.Linq;
using AoC_main.LoadInput;
using AoC_main.LoadInput.RawData;

namespace AoC_main.Solutions
{
    public class DayFourSolution : ISolution<DayFour>
    {
        public IResult SolutionOne(IEnumerable<DayFour> rawData)
        {
            var dayData = rawData.First();

            var winningNumbers = dayData.WinningNumbers.ToList();

            foreach (var number in winningNumbers)
            {
                AddPoint(dayData, number);

                foreach (var board in dayData.GameBoards.Select(((board, i) => new { board, i })))
                {
                    if (CheckIfIsBingo(board.board))
                    {
                        var result = CalculateResult(board.board);

                        return new DayFourResult() { Result = number * result };
                    }
                }
            }

            return null;

        }

        public IResult SolutionTwo(IEnumerable<DayFour> rawData)
        {
            var dayData = rawData.First();

            var winningNumbers = dayData.WinningNumbers.ToList();

            foreach (var number in winningNumbers)
            {
                AddPoint(dayData, number);

                foreach (var board in dayData.GameBoards.Select(((board, i) => new { board, i })).ToList())
                {
                    var isBingo = CheckIfIsBingo(board.board);
                    if (isBingo && dayData.GameBoards.Count == 1)
                    {
                        var result = CalculateResult(board.board);

                        return new DayFourResult() { Result = number * result };
                    } 
                    else if (isBingo)
                    {
                        dayData.GameBoards.Remove(board.board);
                    }
                }
            }

            return null;

        }

        
        private int CalculateResult(DayFourBoardPoint[][] board)
        {
            var sum = 0;
            foreach (var line in board)
            {
                foreach (var item in line)
                {
                    if (!item.IsChecked)
                        sum += item.Value;
                }
            }

            return sum;
        }
        
        private void AddPoint(DayFour boards, int winningNumber)
        {
            foreach (var board in boards.GameBoards)
            {
                foreach (var line in board)
                {
                    foreach (var point in line)
                    {
                        if (point.Value == winningNumber)
                            point.IsChecked = true;
                    }
                }
            }
        }
        
        private bool CheckIfIsBingo(DayFourBoardPoint[][] gameBoard)
        {
            for (int column = 0; column < gameBoard.Length; column++)
            {
                for (int line = 0; line < gameBoard[column].Length; line++)
                {
                    if (!gameBoard[column][line].IsChecked)
                        line += 5;
                    else if (line == 4)
                        return true;
                }
            }
            
            for (int line = 0; line < gameBoard.Length; line++)
            {
                for (int column = 0; column < gameBoard[line].Length; column++)
                {
                    if (!gameBoard[column][line].IsChecked)
                        column += 5;
                    else if (column == 4)
                        return true;
                }
            }

            return false;
        }
    }
}