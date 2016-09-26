

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SmartLilly
    {
        static void Main()
        {
            int age = int.Parse(Console.ReadLine());
            double LaundryMachinePrice = double.Parse(Console.ReadLine());
            int toyPriice = int.Parse(Console.ReadLine());

            int toys = 0;
            int birthdayMoney = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 != 0)
                {
                    toys++;
                }
                else
                {
                    birthdayMoney = birthdayMoney + ((i * 5) - 1);
                }
            }

            int toysMoney = toys * toyPriice;
            int totalMoney = toysMoney + birthdayMoney;

            if (totalMoney >= LaundryMachinePrice)
            {
                Console.WriteLine("Yes! {0:f2}", totalMoney - LaundryMachinePrice);
            }
            else
            {
                Console.WriteLine("No! {0:f2}", LaundryMachinePrice - totalMoney);
            }
        }
    }
}
