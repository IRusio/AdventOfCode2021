using System;
using System.Collections.Generic;
using System.Linq;
using AoC_main.LoadInput.RawData;
using AoC_main.Solutions.Results;

namespace AoC_main.Solutions
{
    public class DayFiveSolution : ISolution<DayFive>
    {
        public IResult SolutionOne(IEnumerable<DayFive> rawData)
        {
            var activeSpots = new Dictionary<(int x, int y), int>();

            foreach (var locations in rawData)
            {
                var firstPoint = locations.From.Split(',').Select(int.Parse).ToList();
                var secondPoint = locations.To.Split(',').Select(int.Parse).ToList();
                if ((firstPoint[0] - secondPoint[0] == 0) && (firstPoint[1] - secondPoint[1] < 0))
                    UpdateSpots(firstPoint[0], secondPoint[0], firstPoint[1], secondPoint[1], activeSpots, true);
                else if ((firstPoint[0] - secondPoint[0] == 0) && (firstPoint[1] - secondPoint[1] > 0))
                    UpdateSpots(firstPoint[0], secondPoint[0], secondPoint[1], firstPoint[1], activeSpots, true);
                else if ((firstPoint[1] - secondPoint[1] == 0) && (firstPoint[0] - secondPoint[0] < 0))
                    UpdateSpots(firstPoint[0], secondPoint[0], firstPoint[1], secondPoint[1], activeSpots,false);
                else if ((firstPoint[1] - secondPoint[1] == 0) && (firstPoint[0] - secondPoint[0] > 0))
                    UpdateSpots(secondPoint[0],firstPoint[0], firstPoint[1], secondPoint[1],  activeSpots,false);
                else Console.WriteLine($"one: {firstPoint[0]},{firstPoint[1]} two: {secondPoint[0]},{secondPoint[1]}");
            }

            var dangerousSpots = activeSpots.Values.Count(x => x >= 2);

            return new DayFiveResult(){ Result = dangerousSpots};
        }

        public IResult SolutionTwo(IEnumerable<DayFive> rawData)
        {
            var activeSpots = new Dictionary<(int x, int y), int>();
            
            foreach (var locations in rawData)
            {
                var firstPoint = locations.From.Split(',').Select(int.Parse).ToList();
                var secondPoint = locations.To.Split(',').Select(int.Parse).ToList();
                
                //vertical
                if ((firstPoint[0] - secondPoint[0] == 0) && (firstPoint[1] - secondPoint[1] < 0))
                    UpdateSpots(firstPoint[0], secondPoint[0], firstPoint[1], secondPoint[1], activeSpots, true);
                else if ((firstPoint[0] - secondPoint[0] == 0) && (firstPoint[1] - secondPoint[1] > 0))
                    UpdateSpots(firstPoint[0], secondPoint[0], secondPoint[1], firstPoint[1], activeSpots, true);
                //horizontal
                else if ((firstPoint[1] - secondPoint[1] == 0) && (firstPoint[0] - secondPoint[0] < 0))
                    UpdateSpots(firstPoint[0], secondPoint[0], firstPoint[1], secondPoint[1], activeSpots,false);
                else if ((firstPoint[1] - secondPoint[1] == 0) && (firstPoint[0] - secondPoint[0] > 0))
                    UpdateSpots(secondPoint[0], firstPoint[0], firstPoint[1], secondPoint[1], activeSpots, false);
                //diagonal
                else UpdateDiagonal(firstPoint, secondPoint, activeSpots);
            }

            var dangerousSpots = activeSpots.Values.Count(x => x >= 2);
            
            
            return new DayFiveResult(){ Result = dangerousSpots};
        }

        private void UpdateDiagonal(List<int> firstPoint, List<int> secondPoint, Dictionary<(int x, int y),int> activeSpots)
        {
            var one = (x: firstPoint[0], y: firstPoint[1]);
            var two = (x: secondPoint[0], y: secondPoint[1]);

            if(one.x < two.x && one.y < two.y)
                for (int i = one.x, j= one.y; i <= two.x && j <= two.y; i++, j++)
                {
                    if (!activeSpots.ContainsKey((i, j)))
                        activeSpots.Add((i, j), 1);
                    else activeSpots[(i, j)] += 1;
                }
            else if(one.x < two.x && one.y > two.y)
                for (int i = one.x, j= one.y; i <= two.x && j >= two.y; i++, j--)
                {
                    if (!activeSpots.ContainsKey((i, j)))
                        activeSpots.Add((i, j), 1);
                    else activeSpots[(i, j)] += 1;
                }
            else if(one.x > two.x && one.y < two.y)
                for (int i = one.x, j= one.y; i >= two.x && j <= two.y; i--, j++)
                {
                    if (!activeSpots.ContainsKey((i, j)))
                        activeSpots.Add((i, j), 1);
                    else activeSpots[(i, j)] += 1;
                }
            else if(one.x > two.x && one.y > two.y)
                for (int i = one.x, j= one.y; i >= two.x && j >= two.y; i--, j--)
                {
                    if (!activeSpots.ContainsKey((i, j)))
                        activeSpots.Add((i, j), 1);
                    else activeSpots[(i, j)] += 1;
                }
        }

        private static void UpdateSpots(int x1, int x2, int y1, int y2, Dictionary<(int x, int y), int> activeSpots, bool vertically)
        {
            if(vertically)
                for (int i = y1; i <= y2; i++)
                {
                    if (!activeSpots.ContainsKey((x1, i)))
                        activeSpots.Add((x1, i), 1);
                    else activeSpots[(x1, i)] += 1;
                }
            else
                for (int i = x1; i <= x2; i++)
                {
                    if (!activeSpots.ContainsKey((i, y1)))
                        activeSpots.Add((i, y1), 1);
                    else activeSpots[(i, y1)] += 1;
                }
        }
    }
}