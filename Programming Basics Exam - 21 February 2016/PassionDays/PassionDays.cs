

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PassionDays
    {
        static void Main()
        {
            decimal money = decimal.Parse(Console.ReadLine());
            Console.ReadLine();

            string info;
            long purchases = 0;
            while ((info = Console.ReadLine()) != "mall.Exit")
            {
                foreach (var ch in info)
                {
                    if (ch == '*')
                    {
                        money += 10;
                        continue;
                    }
                    else if (ch == '%')
                    {
                        if (money>0)
                        {
                            money /= 2;
                            purchases++;
                        }                  
                    }
                    else if (ch >= 65 && ch <= 90)
                    {
                        if (money< ch * 0.5m)
                        {
                            continue;
                        }
                        money = money - (decimal)(ch * 0.5m);
                        purchases++;
                    }
                    else if (ch >= 97 && ch <= 122)
                    {
                        if (money < ch * 0.3m)
                        {
                            continue;
                        }
                        money = money - (decimal)(ch * 0.3m);
                        purchases++;
                    }
                    else
                    {
                        if (money < ch)
                        {
                            continue;
                        }
                        money = money - ch;
                        purchases++;
                    }
                }
            }

            if (purchases == 0)
            {
                Console.WriteLine("No purchases. Money left: {0:f2} lv.", money);
            }
            else
            {
                Console.WriteLine("{0} purchases. Money left: {1:f2} lv.", purchases, money);
            }
        }
    }
}
