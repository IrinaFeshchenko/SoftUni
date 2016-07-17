


namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BookProblem
    {
        static void Main()
        {
            long pages = long.Parse(Console.ReadLine());
            long holidays = long.Parse(Console.ReadLine());
            long pagesPerDay = long.Parse(Console.ReadLine());

            if (holidays >= 30||pagesPerDay==0)
            {
                Console.WriteLine("never");
            }
            else
            {
                long readingdays = 30 - holidays;
                long pagesPerMonth = pagesPerDay * readingdays;
                decimal requiredMonths = Math.Ceiling((decimal)pages / pagesPerMonth);

                Console.WriteLine("{0} years {1} months", (int)requiredMonths / 12, requiredMonths % 12);
            }
        }
    }
}
