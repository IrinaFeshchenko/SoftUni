

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SpiralMatrix
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string keyword = Console.ReadLine();

            char[,] matrix = new char[n, n];
            int left = 0;
            int right = n-1;
            int top = 0;
            int bottom = n-1;
            int len = n * n;

            for (int c = 0; c <= len;)
            {
                for (int col = left; col <= right; col++)
                {
                    //walk right, left to rigth
                    matrix[top, col] = keyword[c % keyword.Length];
                    c++;
                }
                top++;

                for (int row = top; row <= bottom; row++)
                {
                    //walk down, top to bottom
                    matrix[row,right] = keyword[c % keyword.Length];
                    c++;
                }
                right--;

                for (int col = right; col >= left; col--)
                {
                    //walk left, rigth to left
                    matrix[bottom, col] = keyword[c % keyword.Length];
                    c++;
                }
                bottom--;

                if ((top >= bottom) && (left >= right))
                {
                    break;
                }

                for (int row = bottom; row >= top; row--)
                {
                    //walk up, bottom to top
                    matrix[row, left] = keyword[c % keyword.Length];
                    c++;
                }
                left++;
            }

            int[] count = new int[n];
            int max = 0;
            int maxIndex = -1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    count[i] += (char.ToLower(matrix[i, j]) - 96)*10;
                }

                if (count[i]>max)
                {
                    max = count[i];
                    maxIndex = i;
                }
            }

            Console.WriteLine("{0} - {1}", maxIndex, max);
        }
    }
}
