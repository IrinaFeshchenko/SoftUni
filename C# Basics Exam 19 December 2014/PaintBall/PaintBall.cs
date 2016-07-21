


namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PaintBall
    {
        static void Main()
        {
            int[] rows = new int[10];
            int height = 10;
            int width = 10;

            for (int i = 0; i < height; i++)
            {
                rows[i] |= 1023;
            }

            int shots = 0;
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                shots++;

                string[] param = command.Split();
                int row = int.Parse(param[0]);
                int col = int.Parse(param[1]);
                int rad = int.Parse(param[2]);

                int startRow = (row - rad) >= 0 ? (row - rad) : 0;
                int startCol = (col - rad) >= 0 ? (col - rad) : 0;
                int endRow = (row + rad) < height ? (row + rad) : height - 1;
                int endCol = (col + rad) < width ? (col + rad) : width - 1;

                for (int i = startRow; i <= endRow; i++)
                {
                    for (int j = startCol; j <= endCol; j++)
                    {
                        if (shots % 2 != 0)
                        {// black to 0
                            rows[i] &= ~(1 << j);
                        }
                        else
                        { // white to 1
                            rows[i] |= (1 << j);
                        }
                    }
                }
            }

            int sum = rows.Sum();
            Console.WriteLine(sum);
        }
    }
}
