using System;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Day1Part1();
            Day1Part2();
            Day2Part1();
            Day2Part2();
            Day3Part1();
        }

        private static void Day1Part1()
        {
            var input = System.IO.File.ReadAllLines("day1Input.txt");

            var largerThanPreviousCount = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (i == 0)
                    continue;

                var depth = int.Parse(input[i]);
                var depthPrevious = int.Parse(input[i - 1]);

                if (depth > depthPrevious)
                    largerThanPreviousCount++;
            }

            Console.WriteLine($"Larger than previous count: {largerThanPreviousCount}");
        }

        private static void Day1Part2()
        {
            var input = System.IO.File.ReadAllLines("day1Input.txt");

            var largerThanPreviousCount = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (i == 0 || i == 1 || i == 2)
                    continue;

                var depthMeasurement1 = int.Parse(input[i - 3]);
                var depthMeasurement2 = int.Parse(input[i - 2]);
                var depthMeasurement3 = int.Parse(input[i - 1]);
                var depthMeasurement4 = int.Parse(input[i]);

                var sumPrevious = depthMeasurement1 + depthMeasurement2 + depthMeasurement3;
                var sumCurrent = depthMeasurement2 + depthMeasurement3 + depthMeasurement4;

                if (sumCurrent > sumPrevious)
                    largerThanPreviousCount++;
            }

             Console.WriteLine($"Larger than previous count: {largerThanPreviousCount}");
        }

        private static void Day2Part1()
        {
            var input = System.IO.File.ReadAllLines("day2Input.txt");

            var horizontalTracker = 0;
            var depthTracker = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var command = input[i];

                if (command.StartsWith("forward"))
                {
                    var position = int.Parse(command.Replace("forward ", string.Empty));
                    horizontalTracker += position;
                }

                if (command.StartsWith("up"))
                {
                    var position = int.Parse(command.Replace("up ", string.Empty));
                    depthTracker -= position;
                }

                if (command.StartsWith("down"))
                {
                    var position = int.Parse(command.Replace("down ", string.Empty));
                    depthTracker += position;
                }
            }

            Console.WriteLine($"Final horizonal position: {horizontalTracker}");
            Console.WriteLine($"Final depth position: {depthTracker}");
            Console.WriteLine($"Final horizonal position mutiplied by final depth position: {horizontalTracker * depthTracker}");
        }

        private static void Day2Part2()
        {
            var input = System.IO.File.ReadAllLines("day2Input.txt");

            var horizontalTracker = 0;
            var depthTracker = 0;
            var aimTracker = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var command = input[i];

                if (command.StartsWith("forward"))
                {
                    var position = int.Parse(command.Replace("forward ", string.Empty));
                    horizontalTracker += position;
                    depthTracker += (aimTracker * position);
                }

                if (command.StartsWith("up"))
                {
                    var position = int.Parse(command.Replace("up ", string.Empty));
                    aimTracker -= position;
                }

                if (command.StartsWith("down"))
                {
                    var position = int.Parse(command.Replace("down ", string.Empty));
                    aimTracker += position;
                }
            }

            Console.WriteLine($"Final horizonal position: {horizontalTracker}");
            Console.WriteLine($"Final depth position: {depthTracker}");
            Console.WriteLine($"Final horizonal position mutiplied by final depth position: {horizontalTracker * depthTracker}");
        }

        private static void Day3Part1()
        {
            var input = System.IO.File.ReadAllLines("day3Input.txt");

            var zeroCount = 0;
            var oneCount = 0;

            string gammaRate = string.Empty;
            string epsilonRate = string.Empty;
            var columnLength = input[0].Length;

            for (int columnIndex = 0; columnIndex < columnLength; columnIndex++)
            {
                for (int rowIndex = 0; rowIndex < input.Length; rowIndex++)
                {
                    var number = input[rowIndex];
                    var firstBit = int.Parse(number.Substring(columnIndex, 1));

                    if (firstBit == 0)
                        zeroCount++;

                    if (firstBit == 1)
                        oneCount++;
                }

                if (zeroCount > oneCount)
                {
                    gammaRate = $"{gammaRate}0";
                    epsilonRate = $"{epsilonRate}1";
                }

                if (oneCount > zeroCount)
                {
                    gammaRate = $"{gammaRate}1";
                    epsilonRate = $"{epsilonRate}0";
                }

                zeroCount = 0;
                oneCount = 0;
            }

            var gammaRateDecimal = Convert.ToInt32(gammaRate, 2);
            var epsilonRateDecimal = Convert.ToInt32(epsilonRate, 2);

            Console.WriteLine($"Gamma Rate: {gammaRateDecimal}");
            Console.WriteLine($"Epsilon Rate: {epsilonRateDecimal}");
            Console.WriteLine($"Power Consumption {gammaRateDecimal * epsilonRateDecimal}");
        }
    }
}
