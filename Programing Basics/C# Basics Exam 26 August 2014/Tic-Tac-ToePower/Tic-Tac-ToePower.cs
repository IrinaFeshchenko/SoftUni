

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TicTacToePower
    {
        static void Main()
        {
            long x = long.Parse(Console.ReadLine());
            long y = long.Parse(Console.ReadLine());
            long firstCellValue = long.Parse(Console.ReadLine());

            long index = (y * 3) + x;
            long indexValue = firstCellValue + index;
            decimal value = indexValue;

            for (int i = 0; i < index; i++)
            {
                value *= indexValue;
            }
            Console.WriteLine(value);
        }
    }
}
