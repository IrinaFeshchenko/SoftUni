

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StudentCables
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int totalLenght = 0;
            int cablesCount = 0;
            for (int i = 0; i < n; i++)
            {
                int lenght = int.Parse(Console.ReadLine());
                string type = Console.ReadLine();

                if (type == "meters")
                {
                    lenght *= 100;
                }

                if (lenght >= 20 )
                {
                    totalLenght += lenght;
                    cablesCount++;
                }            
            }
            totalLenght -= (cablesCount - 1) * 3;

            int cables = totalLenght / 504;
            int cableLeft = totalLenght % 504;

            Console.WriteLine(cables);
            Console.WriteLine(cableLeft);
        }
    }
}
