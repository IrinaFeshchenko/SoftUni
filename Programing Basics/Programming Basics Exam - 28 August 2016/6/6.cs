

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class six
    {
        static int num = 0;
        static int firsDigit = 0;
        static int secondDigit = 0;
        static int thirdDigit = 0;

        static void Main()
        {
            num = int.Parse(Console.ReadLine());

            firsDigit = num / 100;
            secondDigit = (num / 10) % 10;
            thirdDigit = num % 10;
            int rows = firsDigit+secondDigit;
            int cols = firsDigit+thirdDigit;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    num = Mod(num);
                    Console.Write(num+" ");
                }
                Console.WriteLine();
            }
        }

        private static int Mod(int i)
        {
            if (i % 5 == 0)
            {
                i -= firsDigit;
            }
            else if (i % 3 == 0)
            {
                i -= secondDigit;
            }
            else
            {
                i += thirdDigit;
            }
            return i;
        }
    }
}
