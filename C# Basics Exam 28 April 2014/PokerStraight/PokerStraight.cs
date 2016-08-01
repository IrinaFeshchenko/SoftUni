

namespace Namespace
{
    using System;

    class PokerStraight
    {
        static void Main()
        {
            int weight = int.Parse(Console.ReadLine());

            int count = 0;
            for (int i = 1; i <= 10; i++)
            {
                for (int c1 = 1, f1 = i; c1 <= 4; c1++)
                {
                    for (int c2 = 1, f2 = i + 1; c2 <= 4; c2++)
                    {
                        for (int c3 = 1, f3 = i + 2; c3 <= 4; c3++)
                        {
                            for (int c4 = 1, f4 = i + 3; c4 <= 4; c4++)
                            {
                                for (int c5 = 1, f5 = i + 4; c5 <= 4; c5++)
                                {
                                    long face = f1 * 10 + f2 * 20 + f3 * 30 + f4 * 40 + f5 * 50;
                                    if (face + c1 + c2 + c3 + c4 + c5 == weight)
                                    {
                                        count++;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
