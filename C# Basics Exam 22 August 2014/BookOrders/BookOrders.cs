

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BookOrders
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            long booksCount = 0;
            decimal booksCost = 0;
            for (int i = 0; i < n; i++)
            {

                long packetsCount = long.Parse(Console.ReadLine());
                long booksPerPacket = long.Parse(Console.ReadLine());
                decimal price = decimal.Parse(Console.ReadLine());
                long currentOrderBooksCount = packetsCount * booksPerPacket;
                booksCount += currentOrderBooksCount;

                decimal discount = 0.85m;
                for (int j = 110; j >= 10; j-=10)
                {
                    if (packetsCount>=j)
                    {
                        price *= discount;
                        break;
                    }
                    discount += 0.01m;
                }
                booksCost += currentOrderBooksCount * price;
            }

            Console.WriteLine(booksCount);
            Console.WriteLine("{0:f2}",booksCost);
        }
    }
}
