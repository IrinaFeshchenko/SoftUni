

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BackToThePast
    {
        static void Main()
        {
            decimal money = decimal.Parse(Console.ReadLine());
            int endYear = int.Parse(Console.ReadLine());
            int startYear = 1800;
            int age = 18;

            for (int i = startYear; i <= endYear; i++, age++)
            {
                if (i % 2 == 0)
                {
                    money -= 12000;
                }
                else
                {
                    money -= 12000 + (50 * age);
                }
            }

            if (money>=0)
            {
                Console.WriteLine("Yes! He will live a carefree life and will have {0:f2} dollars left.",money );
            }
            else
            {
                Console.WriteLine("He will need {0:f2} dollars to survive.",Math.Abs(money));
            }
        }
    }
}
