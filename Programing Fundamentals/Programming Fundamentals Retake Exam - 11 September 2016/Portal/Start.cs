

namespace Portal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Cell
    {
        public int row { get; set; }
        public int col { get; set; }
    }

    public class Start
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<string> matrix = ReadMatrix(n);

            string directions = Console.ReadLine();
            Cell currentPosition = GetStartCell(matrix);

            int turns = 0;
            bool foundExit = false;
            for (int i = 0; i < directions.Length; i++)
            {
                turns++;
                char direction = directions[i];

                currentPosition = Move(matrix, currentPosition, direction);
                if (matrix[currentPosition.row][currentPosition.col] == 'E')
                {
                    foundExit = true;
                    break;
                }
            }

            if (foundExit)
            {
                Console.WriteLine($"Experiment successful. {turns} turns required.");
            }
            else
            {
                Console.WriteLine($"Robot stuck at {currentPosition.row} {currentPosition.col}. Experiment failed.");
            }
        }

        private static Cell Move(List<string> matrix, Cell currentPosition, char direction)
        {
            Cell newPosition = new Cell();
            if (direction == 'U')
            {
                newPosition = MoveUp(matrix, currentPosition);
            }
            else if (direction == 'D')
            {
                newPosition = MoveDown(matrix, currentPosition);
            }
            else if (direction == 'L')
            {
                newPosition = MoveLeft(matrix, currentPosition);
            }
            else if (direction == 'R')
            {
                newPosition = MoveRight(matrix, currentPosition);
            }
            return newPosition;
        }

        private static Cell MoveUp(List<string> matrix, Cell currentPosition)
        {
            int row = currentPosition.row;
            int col = currentPosition.col;

            int nextRow = row;
            do
            {
                if (nextRow != 0)
                {
                    nextRow -= 1;
                }
                else
                {
                    nextRow = matrix.Count - 1;
                }
            } while (matrix[nextRow].Length <= col);

            currentPosition.row = nextRow;
            return currentPosition;
        }

        private static Cell MoveDown(List<string> matrix, Cell currentPosition)
        {
            int row = currentPosition.row;
            int col = currentPosition.col;

            int nextRow = row;
            do
            {
                if (nextRow != matrix.Count - 1)
                {
                    nextRow += 1;
                }
                else
                {
                    nextRow = 0;
                }
            } while (matrix[nextRow].Length <= col);

            currentPosition.row = nextRow;
            return currentPosition;
        }

        private static Cell MoveLeft(List<string> matrix, Cell currentPosition)
        {
            int row = currentPosition.row;
            int col = currentPosition.col;

            int nextCol = col;

            if (nextCol != 0)
            {
                nextCol -= 1;
            }
            else
            {
                nextCol = matrix[row].Length - 1;
            }

            currentPosition.col = nextCol;
            return currentPosition;
        }

        private static Cell MoveRight(List<string> matrix, Cell currentPosition)
        {
            int row = currentPosition.row;
            int col = currentPosition.col;

            int nextCol = col;

            if (nextCol != matrix[row].Length - 1)
            {
                nextCol += 1;
            }
            else
            {
                nextCol = 0;
            }

            currentPosition.col = nextCol;
            return currentPosition;
        }

        private static Cell GetStartCell(List<string> matrix)
        {
            Cell startCell = new Cell();

            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'S')
                    {
                        startCell.row = i;
                        startCell.col = j;
                        break;
                    }
                }
            }
            return startCell;
        }

        private static List<string> ReadMatrix(int n)
        {
            List<string> matrix = new List<string>();

            for (int i = 0; i < n; i++)
            {
                matrix.Add(Console.ReadLine());
            }
            return matrix;
        }
    }
}
