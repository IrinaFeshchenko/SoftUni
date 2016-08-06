

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CatchTheBits
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int step = int.Parse(Console.ReadLine());
            int result = 0;
            int nextStep = 1;
            int count = 0;
            
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                while (nextStep<8)
                {
                    result <<= 1;
                    result |= (num>>(7-nextStep))&1;
                    count++;
                    if (count == 8)
                    {
                        Console.WriteLine(result);
                        result = 0;
                        count = 0;
                    }
                    nextStep += step;
                }
                nextStep -= 8;
            }
            if (count!=0)
            {
                Console.WriteLine(result<<8-count);
            }
        }
    }
}
