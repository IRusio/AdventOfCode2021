using System.Linq;
using AoC_main.LoadInput;
using AoC_main.LoadInput.RawData;
using AoC_main.Solutions;

namespace AoC_main
{
    class Program
    {
        static void Main(string[] args)
        {
            // var dayOne = new DailyTaskRunner<DayOne, DayOneSolution>(new DayOneMapper(), new DayOneSolution());
            // dayOne.RunDailyTask();
            //
            // var dayTwo = new DailyTaskRunner<DayTwo, DayTwoSolution>(new DayTwoMapper(), new DayTwoSolution());
            // dayTwo.RunDailyTask();
            //
            // var dayThree = new DailyTaskRunner<DayThree, DayThreeSolution>(new DayThreeMapper(), new DayThreeSolution());
            // dayThree.RunDailyTask();
            //
            // var dayFour = new DailyTaskRunner<DayFour, DayFourSolution>(new DayFourMapper(), new DayFourSolution());
            // dayFour.RunDailyTask();
            //
            // var dayFive = new DailyTaskRunner<DayFive, DayFiveSolution>(new DayFiveMapper(), new DayFiveSolution(), " -> ");
            // dayFive.RunDailyTask();

            // var daySix = new DailyTaskRunner<DaySix, DaySixSolution>(new DaySixMapper(), new DaySixSolution());
            // daySix.RunDailyTask();

            // var daySeven =
            //     new DailyTaskRunner<DaySeven, DaySevenSolution>(new DaySevenMapper(), new DaySevenSolution());
            // daySeven.RunDailyTask();

            var dayEight =
                new DailyTaskRunner<DayEight, DayEightSolution>(new DayEightMapper(), new DayEightSolution());
            dayEight.RunDailyTask();
        }
    }
}