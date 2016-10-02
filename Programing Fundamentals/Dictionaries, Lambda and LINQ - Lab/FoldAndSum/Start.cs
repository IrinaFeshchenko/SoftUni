

namespace FoldAndSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Start
    {
        static void Main()
        {
            int[] num = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int block = num.Length / 4;
            var leftUp = num.Take(block).Reverse();
            var rightUp = num.Skip(block * 3).Take(block).Reverse();
            var firstRow = leftUp.Concat(rightUp);
            var secondRow = num.Skip(block).Take(block * 2);
            var resuslt = firstRow.Zip(secondRow, (x, y )=> x + y);

            Console.WriteLine(string.Join(" ",resuslt));
        }
    }
}
