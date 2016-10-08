

namespace CountWorkingDays
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class Holiday
    {
        public int Day { get; set; }
        public int Month { get; set; }
    }

    public class Start
    {
        public static void Main()
        {
            List<Holiday> holidays = new List<Holiday>();
            holidays.Add(new Holiday { Day = 1, Month = 1 });
            holidays.Add(new Holiday { Day = 3, Month = 3 });
            holidays.Add(new Holiday { Day = 1, Month = 5 });
            holidays.Add(new Holiday { Day = 6, Month = 5 });
            holidays.Add(new Holiday { Day = 24, Month = 5 });
            holidays.Add(new Holiday { Day = 6, Month = 9 });
            holidays.Add(new Holiday { Day = 22, Month = 9 });
            holidays.Add(new Holiday { Day = 1, Month = 11 });
            holidays.Add(new Holiday { Day = 24, Month = 12 });
            holidays.Add(new Holiday { Day = 25, Month = 12 });
            holidays.Add(new Holiday { Day = 26, Month = 12 });

            DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "d-M-yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "d-M-yyyy", CultureInfo.InvariantCulture);

            int workDaysCounter = 0;
            for (DateTime currentDate = startDate; currentDate <= endDate; currentDate = currentDate.AddDays(1))
            {
                if (currentDate.DayOfWeek == DayOfWeek.Saturday ||
                    currentDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    continue;
                }

                int month = currentDate.Month;
                int day = currentDate.Day;

                if (holidays.Any(x=>x.Day ==day && x.Month == month))
                {
                    continue;
                }

                workDaysCounter++;
            }

            Console.WriteLine(workDaysCounter);
        }
    }
}
