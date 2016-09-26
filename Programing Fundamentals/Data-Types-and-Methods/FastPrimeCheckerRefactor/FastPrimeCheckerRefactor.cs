

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FastPrimeCheckerRefactor
    {
        static void Main()
        {
            int range = int.Parse(Console.ReadLine());
            for (int currentNumber = 2; currentNumber <= range; currentNumber++)
            {
                bool isPrime = true;
                for (int i = 2; i <= Math.Sqrt(currentNumber); i++)
                {
                    if (currentNumber % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine($"{currentNumber} -> {isPrime}");
            }
        }
    }
}
