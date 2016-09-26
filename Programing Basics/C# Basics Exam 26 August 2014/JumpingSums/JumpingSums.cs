

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class JumpingSums
    {
        static void Main()
        {
            int[] num = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            long jump = long.Parse(Console.ReadLine());

            int max = int.MinValue;
            for (int i = 0; i < num.Length; i++)
            {
                int index = i;
                int sum = num[index];
                for (int j = 0; j < jump; j++)
                {
                    int MoveLength = num[index];
                    int nextIndex = ((MoveLength+index) % num.Length);
                    index = nextIndex;
                    sum += num[index];
                }
                if (sum>max)
                {
                    max = sum;
                }
            }
            Console.WriteLine("max sum = {0}", max);
        }
    }
}
