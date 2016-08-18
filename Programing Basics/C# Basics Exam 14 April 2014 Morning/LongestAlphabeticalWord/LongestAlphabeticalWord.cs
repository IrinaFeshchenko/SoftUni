

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class LongestAlphabeticalWord
    {
        private enum direction
        {
            down, up, left, right
        }

        static void Main()
        {
            string word = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            char[,] arr = new char[n, n];
            int index = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; index++, j++)
                {
                    arr[i, j] = word[index % word.Length];
                }
            }

            string wordMax = string.Empty;

            for (int direction = 0; direction < 4; direction++)
            {
                for (int i = 0; i < n; i++)
                {
                    string wMax = GetWord((direction)direction, i, n, arr);
                    if (FirstMatchesCondition(wMax, wordMax))
                    {
                        wordMax = wMax;
                    }
                }
            }

            Console.WriteLine(wordMax);
        }

        private static string GetWord(direction direction, int index, int n, char[,] arr)
        {
            int start = 0;
            int end = 0;
            int increment = 0;

            if (direction == direction.down || direction == direction.right)
            {
                start = 0;
                end = n;
                increment = 1;
            }
            else if (direction == direction.up || direction == direction.left)
            {
                start = n - 1;
                end = -1;
                increment = -1;
            }

            char last = ' ';
            char current = ' ';
            string wordMax = string.Empty;
            string wordCurrent = string.Empty;

            for (int i = start; i != end; i += increment)
            {
                if (direction == direction.left || direction == direction.right)
                {
                    current = arr[index, i];
                }
                else
                {
                    current = arr[i, index];
                }

                if (i == start)
                {
                    wordCurrent += current;
                    wordMax += current;
                }
                else
                {
                    if (last < current)
                    {
                        wordCurrent += current;

                        if ((i + increment == end) &&
                            (FirstMatchesCondition(wordCurrent, wordMax)))
                        {
                            wordMax = wordCurrent;
                        }
                    }
                    else
                    {
                        if (FirstMatchesCondition(wordCurrent, wordMax))
                        {
                            wordMax = wordCurrent;
                        }
                        wordCurrent = string.Empty;
                        wordCurrent += current;
                    }
                }

                last = current;
            }

            return wordMax;
        }

        private static bool FirstMatchesCondition(string a, string b)
        {
            if (a.Length > b.Length ||
               (a.Length == b.Length && string.Compare(a, b) < 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
