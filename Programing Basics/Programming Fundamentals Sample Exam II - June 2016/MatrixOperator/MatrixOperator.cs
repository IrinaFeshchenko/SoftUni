

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MatrixOperator
    {
        static List<List<long>> matrix = new List<List<long>>();

        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            for (int i = 0; i < rows; i++)
            {
                matrix.Add(Console.ReadLine().Split().Select(long.Parse).ToList());
            }

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmd = command.Split();
                if (command[0] == 'r')
                {
                    Remove(cmd[1], cmd[2], int.Parse(cmd[3]));
                }
                else if (command[0] == 's')
                {
                    Swap(int.Parse(cmd[1]), int.Parse(cmd[2]));
                }
                else if (command[0] == 'i')
                {
                    Insert(int.Parse(cmd[1]), int.Parse(cmd[2]));
                }
            }

            // print the result matrix
            for (int i = 0; i < matrix.Count; i++)
            {
                Console.WriteLine(String.Join(" ", matrix[i]));
            }
            Console.WriteLine();
        }

        private static void Remove(string type, string direction, int pos)
        {
            if (direction == "row")
            {
                for (int i = 0; i < matrix[pos].Count; i++)
                {
                    if (RemoveType(type, pos, i))
                    {
                        i--;
                    }
                }
            }
            else if (direction == "col")
            {
                for (int i = 0; i < matrix.Count; i++)
                {
                    // if position exist for the row makekchange
                    if (matrix[i].Count > pos)
                    {
                        RemoveType(type, i, pos);
                    }
                }
            }
        }

        private static void Swap(int row1, int row2)
        {
            List<long> buffer = matrix[row1];
            matrix[row1] = matrix[row2];
            matrix[row2] = buffer;
        }

        private static void Insert(int row, int value)
        {
            matrix[row].Insert(0, value);
        }

        private static bool RemoveType(string type, int row, int col)
        {
            bool removed = false;
            if (type == "positive")
            {
                if (matrix[row][col] >= 0)
                {
                    matrix[row].RemoveAt(col);
                    removed = true;
                }
            }
            else if (type == "negative")
            {
                if (matrix[row][col] < 0)
                {
                    matrix[row].RemoveAt(col);
                    removed = true;
                }
            }
            else if (type == "odd")
            {
                if (matrix[row][col] % 2 != 0)
                {
                    matrix[row].RemoveAt(col);
                    removed = true;
                }
            }
            else if (type == "even")
            {
                if (matrix[row][col] % 2 == 0)
                {
                    matrix[row].RemoveAt(col);
                    removed = true;
                }
            }
            return removed;
        }

    }
}
