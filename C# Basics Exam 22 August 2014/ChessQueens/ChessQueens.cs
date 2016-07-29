

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ChessQueens
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine())+1;

            List<int[]> pos1 = new List<int[]>();
            List<int[]> pos2 = new List<int[]>();


            for (int i = 'a'; i < ('a' + n); i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    // up
                    if (IsValidPosition(n, Up(i,j,d)))
                    {
                        pos1.Add(new int[] { i, j });
                        pos2.Add(Up(i, j, d));
                    }
                    // down
                    if (IsValidPosition(n, Down(i, j, d)))
                    {
                        pos1.Add(new int[] { i, j });
                        pos2.Add(Down(i, j, d));
                    }
                    // left
                    if (IsValidPosition(n, Left(i, j, d)))
                    {
                        pos1.Add(new int[] { i, j });
                        pos2.Add(Left(i, j, d));
                    }

                    // right
                    if (IsValidPosition(n, Right(i, j, d)))
                    {
                        pos1.Add(new int[] { i, j });
                        pos2.Add(Right(i, j, d));
                    }

                    // left up diag
                    if (IsValidPosition(n, LeftUp(i, j, d)))
                    {
                        pos1.Add(new int[] { i, j });
                        pos2.Add(LeftUp(i, j, d));
                    }

                    // right up diag
                    if (IsValidPosition(n, RightUp(i, j, d)))
                    {
                        pos1.Add(new int[] { i, j });
                        pos2.Add(RightUp(i, j, d));
                    }

                    // right down diag
                    if (IsValidPosition(n, RightDown(i, j, d)))
                    {
                        pos1.Add(new int[] { i, j });
                        pos2.Add(RightDown(i, j, d));
                    }

                    // left down diag
                    if (IsValidPosition(n, LeftDown(i, j, d)))
                    {
                        pos1.Add(new int[] { i, j });
                        pos2.Add(LeftDown(i, j, d));
                    }
                }
            }

            if (pos1.Count==0)
            {
                Console.WriteLine("No valid positions");
            }
            else
            {
                for (int i = 0; i < pos1.Count; i++)
                {
                    Console.WriteLine("{0}{1} - {2}{3}", (char)pos1[i][0], pos1[i][1], (char)pos2[i][0], pos2[i][1]);
                }
            }
        }

        private static int[] Up(int i, int j, int d)
        {
            return new int[] { i-d, j };
        }
        private static int[] Down(int i, int j, int d)
        {
            return new int[] { i+d, j };
        }
        private static int[] Left(int i, int j, int d)
        {
            return new int[] { i, j + d };
        }
        private static int[] Right(int i, int j, int d)
        {
            return new int[] { i, j - d };
        }
        private static int[] LeftUp(int i, int j, int d)
        {
            return new int[] { i-d, j + d };
        }
        private static int[] RightUp(int i, int j, int d)
        {
            return new int[] { i-d, j - d };
        }
        private static int[] RightDown(int i, int j, int d)
        {
            return new int[] { i+d, j - d };
        }
        private static int[] LeftDown(int i, int j, int d)
        {
            return new int[]{ i+d, j + d};
        }

        private static bool IsValidPosition(int n, int[] pos)
        {
            int i = pos[0];
            int j = pos[1];

            if (i < 'a' || j < 1)
            {
                return false;
            }
            else if ((i >('a' + n - 1) )|| j > n)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
