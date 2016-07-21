

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TextBombardment
    {
        static void Main()
        {
            string text = Console.ReadLine();
            int width = int.Parse(Console.ReadLine());

            int[] bombCol = Console.ReadLine().Split()
                        .Select(int.Parse)
                        .ToArray();

            int rows = (int)Math.Ceiling(text.Length / (double)width);

            char[,] matrix = new char[rows, width];

            int count = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (count == text.Length)
                    {
                        break;
                    }
                    matrix[i, j] = text[count];
                    count++;
                }
            }

            for (int i = 0; i < bombCol.Length; i++)
            {
                bool destroyedCharacter = false;
                for (int row = 0; row < rows; row++)
                {
                    if ((matrix[row, bombCol[i]] == ' '))
                    {
                        if (destroyedCharacter)
                        {
                            break;
                        }
                    }
                    else
                    {
                        matrix[row, bombCol[i]] = ' ';
                        destroyedCharacter = true;
                    }
                }
            }

            count = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (count == text.Length)
                    {
                        break;
                    }
                    Console.Write(matrix[i, j]);
                    count++;
                }
            }
        }
    }
}
