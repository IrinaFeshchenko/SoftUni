namespace _05.Rubik_s_Matrix
{
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            int[] dimentions = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            int rows = dimentions[0];
            int cols = dimentions[1];

            long[][] matrix = new long[rows][];

            int numbers = 1;
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new long[cols];
                for (int j = 0; j < cols; j++)
                {
                    matrix[i][j] = numbers++;
                }
            }

            int inputsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputsCount; i++)
            {
                string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int position = int.Parse(args[0]);
                string command = args[1];
                int steps = int.Parse(args[2]);

                Move(matrix, position, command, steps);
            }

            int element = 1;

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == element)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int r = 0; r < matrix.Length; r++)
                        {
                            for (int k = 0; k < matrix[0].Length; k++)
                            {
                                if (matrix[r][k] == element)
                                {
                                    long currentElement = matrix[i][j];
                                    matrix[i][j] = element;
                                    matrix[r][k] = currentElement;

                                    Console.WriteLine($"Swap ({i}, {j}) with ({r}, {k})");
                                }
                            }
                        }
                    }

                    element++;
                }
            }
        }

        private static void Move(long[][] matrix, int position, string command, int steps)
        {
            if (command == "up")
            {
                MoveCol(matrix, position, steps);
            }
            else if (command == "down")
            {
                MoveCol(matrix, position, matrix.Length - (steps % matrix.Length));
            }
            else if (command == "left")
            {
                MoveRow(matrix, position, steps);
            }
            else if (command == "right")
            {
                MoveRow(matrix, position, matrix[0].Length - (steps % matrix[0].Length));
            }
        }

        private static void MoveRow(long[][] matrix, int position, int steps)
        {
            long[] temp = new long[matrix.Length];

            for (int i = 0; i < matrix.Length; i++)
            {
                temp[i] = matrix[position][(i + steps) % matrix[0].Length];
            }

            matrix[position] = temp;
        }

        private static void MoveCol(long[][] matrix, int position, int steps)
        {
            long[] temp = new long[matrix.Length];

            for (int i = 0; i < matrix.Length; i++)
            {
                temp[i] = matrix[(i + steps) % matrix.Length][position];
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i][position] = temp[i];
            }
        }
    }
}
