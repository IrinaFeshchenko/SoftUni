

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class LargestCommonEnd
    {
        static void Main()
        {
            List<string> line1 = Console.ReadLine().Split().ToList();
            List<string> line2 = Console.ReadLine().Split().ToList();

            int countLeft = 0;
            int length = Math.Min(line1.Count,line2.Count);
            for (int i = 0; i < length; i++)
            {
                if (line1[i] != line2[i])
                {
                    break;
                }
                countLeft++;
            }

            int i1 = line1.Count-1;
            int i2 = line2.Count-1;
            int countRight = 0;
            for (int i = 0; i < length; i++)
            {              
                if (line1[i1] != line2[i2])
                {
                    break;
                }
                countRight++;
                i1--;
                i2--;
            }

            Console.WriteLine(Math.Max(countLeft,countRight));
        }
    }
}
