


namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class four
    {
        static void Main()
        {
            int days = int.Parse(Console.ReadLine());

            int doctors = 7;
            int treated = 0;
            int untreated = 0;
            for (int i = 1; i <= days; i++)
            {
                if (i%3==0&&untreated>treated)
                {
                    doctors++;
                }

                int patients = int.Parse(Console.ReadLine());

                if (patients>doctors)
                {
                    treated += doctors;
                    untreated += patients - doctors;
                }
                else
                {
                    treated += patients;
                }
            }

            Console.WriteLine($"Treated patients: {treated}.");
            Console.WriteLine($"Untreated patients: {untreated}.");
        }
    }
}
