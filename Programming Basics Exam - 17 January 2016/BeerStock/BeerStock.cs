

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BeerStock
    {
        static void Main()
        {
            ulong reserved = ulong.Parse(Console.ReadLine());
            string command;
            ulong totalBeers = 0;

            while ((command = Console.ReadLine()) != "Exam Over")
            {
                string[] param = command.Split();
                ulong amount = ulong.Parse(param[0]);
                string type = param[1];

                if (type == "beers")
                {
                    totalBeers+=amount;
                }
                else if (type == "sixpacks")
                {
                    totalBeers += 6* amount;
                }
                else if (type == "cases")
                {
                    totalBeers += 24* amount;
                }
            }

            totalBeers -= totalBeers / 100;
            if (totalBeers >= reserved)
            {
                ulong left = totalBeers - reserved;
                ulong cases = left / 24;
                ulong sixpacks = (left % 24) / 6;
                ulong beers = (left % 24) % 6;

                Console.WriteLine("Cheers! Beer left: {0} cases, {1} sixpacks and {2} beers.",cases,sixpacks,beers);
            }
            else
            {
                ulong left = reserved - totalBeers;
                ulong cases = left / 24;
                ulong sixpacks = (left % 24) / 6;
                ulong beers = (left % 24) % 6;

                Console.WriteLine("Not enough beer. Beer needed: {0} cases, {1} sixpacks and {2} beers.", cases, sixpacks, beers);
            }
        }
    }
}
