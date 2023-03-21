﻿
namespace AdventOfBlazor.Puzzles.Twenty22
{
    [PuzzleData(Year = 2022, Day = 3, Title = "Rucksack Reorganization", Stars = 1, ImplementedElsewhere = false)]
    public partial class Day3 : IBasicPuzzle
    {
        public (string, string) SplitCompartments(string input)
        {
            var half = input.Length / 2;
            return (input[..half], input[half..]);
        }

        public char GetSharedItem(string first, string second)
        {
            foreach (var char1 in first)
            {
                foreach (var char2 in second)
                {
                    if (char1 == char2)
                    {
                        return char1;
                    }
                }
            }

            return ' ';
        }

        public char GetSharedItem(string first, string second, string third)
        {
            foreach (var char1 in first)
            {
                foreach (var char2 in second)
                {
                    foreach (var char3 in third)
                    {
                        if (char1 == char2 && char2 == char3)
                        {
                            return char1;
                        }
                    }
                }
            }

            return ' ';
        }

        public int GetItemValue(char input)
        {
            if (char.IsAsciiLetterLower(input))
            {
                return ((int)input) - 96;
            }

            if (char.IsAsciiLetterUpper(input))
            {
                return ((int)input) - 38;
            }

            return 0;
        }

        public string[] PartOne(string input)
        {
            var bags = input.Split(Environment.NewLine);
            var sumTotal = 0;

            foreach (var bag in bags)
            {
                var (compartment1, compartment2) = SplitCompartments(bag);
                var item = GetSharedItem(compartment1, compartment2);

                sumTotal += GetItemValue(item);
            }

            return new string[] { sumTotal.ToString() };
        }

        public string[] PartTwo(string input)
        {
            var bags = input.Split(Environment.NewLine);
            var sumTotal = 0;

            for (var i = 0; i < bags.Length; i += 3)
            {
                var item = GetSharedItem(bags[i], bags[i + 1], bags[i + 2]);
                sumTotal += GetItemValue(item);
            }

            return new string[] { sumTotal.ToString() };
        }
    }
}