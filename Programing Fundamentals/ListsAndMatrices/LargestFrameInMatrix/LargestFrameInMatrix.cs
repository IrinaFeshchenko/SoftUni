

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Frame
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public Frame(int width, int height)
        {
            this.Height = height;
            this.Width = width;
        }
    }

    public class cell
    {
        public int value { get; set; }
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
            int[] num = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = num[0];
            int cols = num[1];
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
            //RecordFrames(matrix,frames);//find largest rectangle area
            ShowResult(frames);
        }

        private static void FindLargestFrame(cell[,] matrix, List<cell> bestCandidates, List<Frame> frames)
        {
            int maxRect = 0;
            foreach (var cell in bestCandidates)
            {
                int width = cell.countLeft;
                int height = cell.countUp;

                if (width*height<maxRect) // if next candidates cannot have bigger area, stop checking;
                {
                    break;
                }

                int farRow = cell.row + cell.countUp - 1;
                int farCol = cell.col + cell.countLeft - 1;

                while (farRow > 0 || farCol > 0)
                {
                    int farWidth = matrix[farRow, farCol].countRight;
                    int farHeight = matrix[farRow, farCol].countDown;

                    if (farWidth>=width&&farHeight>=height)
                    {
                        int currentRect = width * height;
                        if (currentRect>=maxRect)
                        {
                            maxRect = currentRect;
                            frames.Add(new Frame(width:width,height:height ));
                            break;
                        }                     
                    }
                    else
                    {
                        if (farRow > farCol)
                        {
                            farRow--;
                            width--;
                        }
                        else
                        {
                            farCol--;
                            height--;
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
           // var result = frames
           //     .Where(f =>
           //     (f.Height * f.Width) == frames
           //                             .Select(fr => fr.Height * fr.Width)
           //                             .Max());
            foreach (var frame in frames)
            {
                Console.WriteLine($"{frame.Height}x{frame.Width}");
            }
        }

        private static void FindLargestArea(cell[,] matrix, List<Frame> frames)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            Queue<cell> queue = new Queue<cell>();

            for (int i = 0; i < rows; i++)
            {
                queue.Enqueue(matrix[i, 0]);
                AddFrame(frames, queue);

                for (int j = 1; j < cols; j++)
                {
                    if (queue.Peek().value == matrix[i, j].value)
                    {
                        queue.Enqueue(matrix[i, j]);
                        AddFrame(frames, queue);
                    }
                    else
                    {
                        while (queue.Count != 0)
                        {
                            queue.Dequeue();
                            if (queue.Count != 0)
                            {
                                AddFrame(frames, queue);
                            }
                        }

                        queue = new Queue<cell>();
                        queue.Enqueue(matrix[i, j]);
                    }
                }
            }
        }

        private static void AddFrame(List<Frame> frames, Queue<cell> queue)
        {
            Frame f = new Frame(width: queue.Count,
                              height: queue
                              .Select(cell => cell.countUp)
                              .Min());
            frames.Add(f);
        }

        private static void ReadInputMatrix(cell[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();
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

        private static void PrintMatrixCounts(cell[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col].countDown + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
