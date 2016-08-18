

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class KnightPath
    {
        static void Main()
        {
            Dictionary<string, int> direction = new Dictionary<string, int>();
            direction.Add("left", 1);
            direction.Add("right",-1);
            direction.Add("up", -1);
            direction.Add("down", 1);

            int n = 8;
            uint[] board = new uint[n];
            board[0] = 1;

            int row = 0;
            int rCol = 0;

            string command;
            while ((command = Console.ReadLine()) != "stop")
            {
                string d1 = command.Split()[0];
                string d2 = command.Split()[1];
                int nextRow = row;
                int nextRCol = rCol;

                if (d1 == "left" || d1 == "right")
                {
                    nextRCol += 2 * direction[d1];
                }
                else if (d1 == "up" || d1 == "down")
                {
                    nextRow += 2 * direction[d1];
                }

                if (d2 == "left" || d2 == "right")
                {
                    nextRCol += direction[d2];
                }
                else if (d2 == "up" || d2 == "down")
                {
                    nextRow += direction[d2];
                }

                if (IsValidPosition(nextRow, nextRCol, n))
                {
                    row = nextRow;
                    rCol = nextRCol;
                    board[row] ^= (1u << rCol);
                }
            }

            bool empty = true;
            foreach (var number in board)
            {
                if (number !=0)
                {
                    empty = false;
                    Console.WriteLine(number);
                }
            }
            if (empty)
            {
                Console.WriteLine("[Board is empty]");
            }
        }

        private static bool IsValidPosition(int row, int rCol, int n)
        {
            bool isValid = false;
            if ((0 <= row && row < n) & (0 <= rCol && rCol < n))
            {
                isValid = true;
            }
            return isValid;
        }
    }
}
