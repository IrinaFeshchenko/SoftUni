
namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BitsatCrossroads
    {

        static List<ulong> board = new List<ulong>();
        static int n = 0;
        static int crossroads = 0;

        static void Main()
        {

            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                board.Add(0);
            }

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] param = command.Split();
                int row = int.Parse(param[0]);
                int rcol = int.Parse(param[1]);

                crossroads++;
                fillLeftUp(row, rcol);
                fillLeftDown(row, rcol);
                fillRighttUp(row, rcol);
                fillRightDown(row, rcol);
            }
            ShowResult();
        }

        private static void ShowResult()
        {
            foreach (var row in board)
            {
                Console.WriteLine(row);
            }
            Console.WriteLine(crossroads);
        }

        private static void fillLeftUp(int row, int rcol)
        {
            for (; (row >= 0) && (rcol < n); row--, rcol++)
            {
                if (((board[row] >> rcol) & 1) == 1)
                {
                    crossroads++;
                }
                board[row] |= (1UL << rcol);
            }
        }
        private static void fillLeftDown(int row, int rcol)
        {
            row++;
            rcol++;
            for (; (row < n) && (rcol < n); row++, rcol++)
            {
                if (((board[row] >> rcol) & 1) == 1)
                {
                    crossroads++;
                }
                board[row] |= (1UL << rcol);
            }
        }
        private static void fillRighttUp(int row, int rcol)
        {
            row--;
            rcol--;
            for (; (row >= 0) && (rcol >= 0); row--, rcol--)
            {
                if (((board[row] >> rcol) & 1) == 1)
                {
                    crossroads++;
                }
                board[row] |= (1UL << rcol);
            }
        }
        private static void fillRightDown(int row, int rcol)
        {
            row++;
            rcol--;
            for (; (row < n) && (rcol >= 0); row++, rcol--)
            {
                if (((board[row] >> rcol) & 1) == 1)
                {
                    crossroads++;
                }
                board[row] |= (1UL << rcol);
            }
        }
    }
}
