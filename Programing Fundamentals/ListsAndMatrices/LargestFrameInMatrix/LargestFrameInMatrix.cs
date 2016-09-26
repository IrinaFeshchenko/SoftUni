

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Frame
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public Frame(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }
    }

    public class cell
    {
        public long value { get; set; }
        public int row { get; set; }
        public int col { get; set; }
        public int countUp { get; set; }
        public int countLeft { get; set; }
        public int countRight { get; set; }
        public int countDown { get; set; }

        public cell()
        {
            countUp = 1;
            countLeft = 1;
            countRight = 1;
            countDown = 1;
            value = 0;
            row = 0;
            col = 0;
        }
    }

    public class LargestFrameInMatrix
    {
        static void Main()
        {
            long[] num = Console.ReadLine().Split().Select(long.Parse).ToArray();
            long rows = num[0];
            long cols = num[1];
            cell[,] matrix = new cell[rows, cols];

            InitialiseEmptyMatrix(matrix);
            ReadInputMatrix(matrix);

            CountUp(matrix);
            CountLeft(matrix);
            CountRight(matrix);
            CountDown(matrix);
            List<Frame> frames = new List<Frame>();
            var bestCandidates = OrderByBestCandidates(matrix).ToList();
            FindLargestFrame(matrix, bestCandidates, frames);
            ShowResult(frames);
        }

        private static void FindLargestFrame(cell[,] matrix, List<cell> bestCandidates, List<Frame> frames)
        {
            long maxRect = 0;
            foreach (var cell in bestCandidates)
            {
                int row = cell.row;
                int col = cell.col;
                //int width = cell.countLeft;
                //int height = cell.countUp;
                int farRow = cell.row + cell.countUp - 1;
                int farCol = cell.col + cell.countLeft - 1;

                for (int i = row; i <= farRow; i++)
                {
                    for (int j = col; j <= farCol; j++)
                    {
                        int farWidth = matrix[i, j].countRight;
                        int farHeight = matrix[i, j].countDown;
                        int height = i - row + 1;
                        int width = j - col + 1;
                        if ((farWidth >= width) && 
                            (farHeight >= height) && 
                            (width*height>=maxRect))
                        {
                            if (width * height > maxRect)
                            {
                                frames.Clear();
                                maxRect = width * height;
                            }

                            frames.Add(new Frame(width: width, height: height));
                        }
                    }
                }
            }
        }

        private static IEnumerable<cell> OrderByBestCandidates(cell[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            List<cell> result = new List<cell>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result.Add(matrix[i, j]);
                }
            }

            result = result.OrderByDescending(cell => cell.countUp * cell.countLeft).ToList();
            return (IEnumerable<cell>)result;
        }

        private static void CountDown(cell[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // count down, left to right
            for (int col = 0; col < cols; col++)
            {
                var lastValue = matrix[0, col].value;

                for (int row = 1; row < rows; row++)
                {
                    var currentValue = matrix[row, col].value;

                    if (currentValue == lastValue)
                    {
                        matrix[row, col].countDown = matrix[row - 1, col].countDown + 1;
                    }
                    else
                    {
                        matrix[row, col].countDown = 1;
                        lastValue = matrix[row, col].value;
                    }
                }
            }
        }

        private static void CountRight(cell[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // count right, top to bottom
            for (int row = 0; row < rows; row++)
            {
                var lastValue = matrix[row, 0].value;

                for (int col = 1; col < cols; col++)
                {
                    var currentValue = matrix[row, col].value;

                    if (currentValue == lastValue)
                    {
                        matrix[row, col].countRight = matrix[row, col - 1].countRight + 1;
                    }
                    else
                    {
                        matrix[row, col].countRight = 1;
                        lastValue = matrix[row, col].value;
                    }
                }
            }
        }

        private static void CountLeft(cell[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // count left, top to bottom
            for (int row = 0; row < rows; row++)
            {
                var lastValue = matrix[row, cols - 1].value;

                for (int col = (cols - 2); col >= 0; col--)
                {
                    var currentValue = matrix[row, col].value;

                    if (currentValue == lastValue)
                    {
                        matrix[row, col].countLeft = matrix[row, col + 1].countLeft + 1;
                    }
                    else
                    {
                        matrix[row, col].countLeft = 1;
                        lastValue = matrix[row, col].value;
                    }
                }
            }
        }

        private static void CountUp(cell[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // count up, left to right
            for (int col = 0; col < cols; col++)
            {
                var lastValue = matrix[rows - 1, col].value;

                for (int row = (rows - 2); row >= 0; row--)
                {
                    var currentValue = matrix[row, col].value;

                    if (currentValue == lastValue)
                    {
                        matrix[row, col].countUp = matrix[row + 1, col].countUp + 1;
                    }
                    else
                    {
                        matrix[row, col].countUp = 1;
                        lastValue = matrix[row, col].value;
                    }
                }
            }
        }

        private static void ShowResult(List<Frame> frames)
        {

            Console.WriteLine(
                string.Join(", ", frames.Select(
                    f => string.Format($"{f.Height}x{f.Width}")
                    ).OrderBy(x => x.ToString()
                    )));
        }

        private static void ReadInputMatrix(cell[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                long[] line = Console.ReadLine().Split().Select(long.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j].value = line[j];
                    matrix[i, j].row = i;
                    matrix[i, j].col = j;
                }
            }
        }

        private static void InitialiseEmptyMatrix(cell[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = new cell();
                }
            }
        }
    }
}
