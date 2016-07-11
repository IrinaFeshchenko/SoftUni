

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MasterHerbalist
    {
        static void Main()
        {
            int expense = int.Parse(Console.ReadLine());
            int days = 0;
            int totalEarn = 0;
            string command;
            while ((command = Console.ReadLine()) != "Season Over")
            {
                days++;
                int dailyEarn = 0;
                string[] parameter = command.Split();
                int hours = int.Parse(parameter[0]);
                string path = parameter[1];
                int price = int.Parse(parameter[2]);
                int herbs = 0;
                for (int i = 0; i < hours; i++)
                {

                    if (path[i % (path.Length)] == 'H')
                    {
                        herbs++;
                    }

                }
                dailyEarn = herbs * price;
                totalEarn += dailyEarn;
            }

            double avgEarn = (double)totalEarn / days;
            double profit = avgEarn - expense;

            if (profit >= 0)
            {
                Console.WriteLine("Times are good. Extra money per day: {0:f2}.", profit);
            }
            else
            {
                Console.WriteLine("We are in the red. Money needed: {0}.", expense * days - totalEarn);
            }
        }
    }
}
