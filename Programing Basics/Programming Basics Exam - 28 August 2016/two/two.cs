

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class two
    {
        static void Main()
        {
            int hoursRequired = int.Parse(Console.ReadLine());
            double daysAvailable = int.Parse(Console.ReadLine());
            double employeesWorkingExtra = int.Parse(Console.ReadLine());


            double standartdaysAvailable = daysAvailable * 0.9;
            double standartWorkHours = standartdaysAvailable * 8.0;

            double extraHours = employeesWorkingExtra * (2.0 * daysAvailable);

            int totalHours = (int)Math.Floor(standartWorkHours + extraHours);

            if (totalHours >= hoursRequired)
            {
                Console.WriteLine($"Yes!{totalHours - hoursRequired} hours left.");
            }
            else
            {
                Console.WriteLine($"Not enough time!{hoursRequired - totalHours} hours needed.");
            }
        }
    }
}
