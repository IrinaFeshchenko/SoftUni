using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2___Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            char[][] arr = new char[n][];

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                arr[i] = line.ToCharArray();
            }


            bool canAttack = false;
            int turns = -1;
            do
            {
                int maxi = -1;
                int maxj = -1;
                int maxHit = 0;
                canAttack = false;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (arr[i][j] == 'K')
                        {
                            int hit = 0;
                            if ((hit = CanAttack(arr, i, j)) > 0)
                            {
                                canAttack = true;
                                if (maxHit < hit)
                                {
                                    maxi = i;
                                    maxj = j;
                                    maxHit = hit;
                                }
                            }
                        }
                    }
                }

                //rem knight
                if (canAttack)
                {
                    arr[maxi][maxj] = 'O';
                }

                turns++;
            } while (canAttack);

            Console.WriteLine(turns);
        }

        private static int CanAttack(char[][] arr, int i, int j)
        {
            int attack = 0;
            if (IsInRange(arr.Length, i-2, j-1))
            {
                if (arr[i - 2][j - 1] == 'K')
                {

                    attack++;
                }
            }

            if (IsInRange(arr.Length, i-2, j+1))
            {
                if (arr[i - 2][j + 1] == 'K')
                {
                    attack++;
                }
            }

            if (IsInRange(arr.Length, i-1, j-2))
            {
                if (arr[i - 1][j - 2] == 'K')
                {
                    attack++;
                }
            }

            if (IsInRange(arr.Length, i-1, j+2))
            {
                if (arr[i - 1][j + 2] == 'K')
                {
                    attack++;
                }
            }

            if (IsInRange(arr.Length, i+2, j-1))
            {
                if (arr[i + 2][j - 1] == 'K')
                {
                    attack++;
                }
            }

            if (IsInRange(arr.Length, i+2, j+1))
            {
                if (arr[i + 2][j + 1] == 'K')
                {
                    attack++;
                }
            }

            if (IsInRange(arr.Length, i+1, j-2))
            {
                if (arr[i + 1][j - 2] == 'K')
                {
                    attack++;
                }
            }

            if (IsInRange(arr.Length, i+1, j+2))
            {
                if (arr[i + 1][j + 2] == 'K')
                {
                    attack++;
                }
            }

            return attack;
        }

        private static bool IsInRange(int len, int i, int j)
        {
            if (i >= 0 && i < len && j >= 0 && j < len)
            {
                return true;
            }
            return false;
        }
    }
}
