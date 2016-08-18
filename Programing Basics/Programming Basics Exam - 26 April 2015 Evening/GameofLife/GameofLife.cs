

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class GameofLife
    {
        struct point
        {
            public point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public int x, y;
        };

        static int[,] board = new int[12, 12];
        static int len = 11;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            // read the input
            for (int i = 0; i < n; i++)
            {
                int x = int.Parse(Console.ReadLine());
                int y = int.Parse(Console.ReadLine());
                board[x + 1, 10 - y] = 1;
            }

            List<point> nextState = new List<point>();
            //for each cell on board
            for (int i = 1; i < len; i++)
            {
                for (int j = 1; j < len; j++)
                {
                    if (willLive(i, j))
                    {
                        nextState.Add(new point(i, j));
                    }
                }
            }

            // clean the board
            for (int i = 1; i < len; i++)
            {
                for (int j = 1; j < len; j++)
                {
                    board[i, j] = 0;
                }
            }

            // update to the new state
            foreach (var pt in nextState)
            {
                board[pt.x, pt.y] = 1;
            }

            // output
            for (int i = 1; i < len; i++)
            {
                for (int j = 1; j < len; j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static bool willLive(int i, int j)
        {
            bool isAlive = board[i, j] == 1;
            bool willLive = false;
            int neibhors = 0;

            // count the neibhors of the cell
            for (int r = i - 1; r < i + 2; r++)
            {
                for (int c = j - 1; c < j + 2; c++)
                {
                    if ((board[r, c] == 1) && !((r == i) && (c == j)))
                    {
                        neibhors++;
                    }
                }
            }

            if (isAlive && (neibhors < 2) || (neibhors > 3))
            {
                willLive = false;
            }
            else if (isAlive && (neibhors == 2) || (neibhors == 3))
            {
                willLive = true;
            }
            else if (!isAlive && (neibhors == 3))
            {
                willLive = true;
            }

            return willLive;
        }
    }
}
