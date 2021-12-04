using System;
using System.Collections.Generic;

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
            Day3Part2();
            Day4Part1();
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

            var gammaRate = string.Empty;
            var epsilonRate = string.Empty;
            var columnLength = input[0].Length;

            for (int columnIndex = 0; columnIndex < columnLength; columnIndex++)
            {
                for (int rowIndex = 0; rowIndex < input.Length; rowIndex++)
                {
                    var number = input[rowIndex];
                    var bit = int.Parse(number.Substring(columnIndex, 1));

                    if (bit == 0)
                        zeroCount++;

                    if (bit == 1)
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

        private static void Day3Part2()
        {
            var input = System.IO.File.ReadAllLines("day3Input.txt");

            var oxygenGeneratorRating = FilterNumbers(input, 0, true);
            var c02ScrubberRating = FilterNumbers(input, 0, false);

            string FilterNumbers(string[] numbers, int columnIndex, bool findMostCommonValue)
            {
                var zeroCount = 0;
                var oneCount = 0;
                var bitCriteria = string.Empty;
                var filteredNumbers = new List<string>();

                for (int rowIndex = 0; rowIndex < numbers.Length; rowIndex++)
                {
                    var number = numbers[rowIndex];
                    var bit = int.Parse(number.Substring(columnIndex, 1));

                    if (bit == 0)
                        zeroCount++;

                    if (bit == 1)
                        oneCount++;
                }

                if (zeroCount > oneCount)
                    bitCriteria = findMostCommonValue ? "0" : "1";

                if (oneCount > zeroCount)
                    bitCriteria = findMostCommonValue ? "1" : "0";

                if (oneCount == zeroCount)
                    bitCriteria = findMostCommonValue ? "1" : "0";

                for (int rowIndex = 0; rowIndex < numbers.Length; rowIndex++)
                {
                    var number = numbers[rowIndex];
                    var bit = number.Substring(columnIndex, 1);

                    if (bit == bitCriteria)
                        filteredNumbers.Add(number);
                }

                if (filteredNumbers.Count == 1)
                    return filteredNumbers[0];

                return FilterNumbers(filteredNumbers.ToArray(), columnIndex + 1, findMostCommonValue);
            }

            var oxygenGeneratorRatingDecimal = Convert.ToInt32(oxygenGeneratorRating, 2);
            var c02ScrubberRatingDecimal = Convert.ToInt32(c02ScrubberRating, 2);

            Console.WriteLine($"Oxygen Generator Rating: {oxygenGeneratorRatingDecimal}");
            Console.WriteLine($"C02 Scrubber Rating: {c02ScrubberRatingDecimal}");
            Console.WriteLine($"Life Support Rating {oxygenGeneratorRatingDecimal * c02ScrubberRatingDecimal}");
        }

        private static void Day4Part1()
        {
            var input = System.IO.File.ReadAllLines("day4Input.txt");
            var bingoNumbers = input[0].Split(',');
            var boards = new List<Tuple<bool, string>[,]>();

            // Draw boards
            for (int inputRowIndex = 2; inputRowIndex < input.Length; inputRowIndex += 6)
            {
                var board = new Tuple<bool, string>[5,5];

                for (int boardRowIndex = 0; boardRowIndex < 5; boardRowIndex++)
                {
                    var columns = input[inputRowIndex + boardRowIndex].Split(' ');
                    columns = Array.FindAll(columns, c => !string.IsNullOrEmpty(c)); // Remove empty values in array

                    for (int boardColumnIndex = 0; boardColumnIndex < columns.Length; boardColumnIndex++)
                        board[boardRowIndex, boardColumnIndex] = new Tuple<bool, string>(false, columns[boardColumnIndex]);
                }

                boards.Add(board);
            }

            var winningNumber = string.Empty;
            var winningBoardIndex = default(int);

            // Simulate Bingo
            for (int i = 0; i < bingoNumbers.Length; i++)
            {
                var bingoNumber = bingoNumbers[i];

                for (int boardIndex = 0; boardIndex < boards.Count; boardIndex++)
                {
                    var board = boards[boardIndex];

                    for (int boardRowIndex = 0; boardRowIndex < 5; boardRowIndex++)
                    {
                        for (int boardColumnIndex = 0; boardColumnIndex < 5; boardColumnIndex++)
                        {
                            if (bingoNumber == board[boardRowIndex, boardColumnIndex].Item2)
                                board[boardRowIndex, boardColumnIndex] = new Tuple<bool, string>(true, board[boardRowIndex, boardColumnIndex].Item2);
                        }
                    }
                }

                // Analyse boards
                for (int boardIndex = 0; boardIndex < boards.Count; boardIndex++)
                {
                    var board = boards[boardIndex];
                    var rowCounter = 0;
                    for (int rowIndex = 0; rowIndex < 5; rowIndex++)
                    {
                        for (int columnIndex = 0; columnIndex < 5; columnIndex++)
                        {
                            if (board[rowIndex, columnIndex].Item1 == true)
                                rowCounter++;

                            if (rowCounter == 5)
                            {
                                Console.WriteLine("Bingo!");
                                winningNumber = bingoNumber;
                                winningBoardIndex = boardIndex;
                                rowCounter = 0;
                            }
                        }
                        rowCounter = 0;
                    }

                    var columnCounter = 0;
                    for (int columnIndex = 0; columnIndex < 5; columnIndex++)
                    {
                        for (int rowIndex = 0; rowIndex < 5; rowIndex++)
                        {
                            if (board[rowIndex, columnIndex].Item1 == true)
                                columnCounter++;

                            if (columnCounter == 5)
                            {
                                Console.WriteLine("Bingo!");
                                winningNumber = bingoNumber;
                                winningBoardIndex = boardIndex;
                                columnCounter = 0;
                            }
                        }
                        columnCounter = 0;
                    }
                }

                if (string.IsNullOrEmpty(winningNumber))
                    continue;

                // Answer question
                var sumOfUnmarked = 0;
                var winningBoard = boards[winningBoardIndex];
                for (int rowIndex = 0; rowIndex < 5; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < 5; columnIndex++)
                    {
                        if (winningBoard[rowIndex, columnIndex].Item1 == false)
                            sumOfUnmarked += int.Parse(winningBoard[rowIndex, columnIndex].Item2);
                    }
                }

                var finalScore = sumOfUnmarked * int.Parse(winningNumber);

                Console.WriteLine($"Final Score: {finalScore}");
                break;
            }
        }
    }
}
