
namespace Cubic_s_Rube
{
    using System;
    using System.Numerics;

    class Startup
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int unchangedCount = n*n*n;
            long sum = 0L;
            string line;

            while ((line = Console.ReadLine()) != "Analyze")
            {
                var input = line.Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
                int x = int.Parse(input[0]);
                int y = int.Parse(input[1]);
                int z = int.Parse(input[2]);
                int patricle = int.Parse(input[3]);

                if ((isInRange(x, y, z, n)))
                {
                    if (patricle != 0)
                    {
                        sum += patricle;
                        unchangedCount--;
                    }
                }
            }

            Console.WriteLine(sum);
            Console.WriteLine(unchangedCount);
        }

        private static bool isInRange(int x, int y, int z, int n)
        {
            return x < n && x >= 0 &&
                   y < n && y>=0 &&
                   z < n && z>=0;
        }
    }
}
