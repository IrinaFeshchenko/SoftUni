

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    class DayOfWeek
    {
        static void Main()
        {
            string dateAsString = Console.ReadLine();
            DateTime date = DateTime.ParseExact(dateAsString,"d-M-yyyy",CultureInfo.InvariantCulture);

            Console.WriteLine(date.DayOfWeek);
        }
    }
}
