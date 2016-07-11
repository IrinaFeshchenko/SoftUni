

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Trim
    {
        static void Main()
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string destination;
            string facility;

            if (budget <= 100)
            {
                if (season == "summer")
                {
                    budget *= 0.3;
                    facility = "Camp";
                }
                else
                {
                    budget *= 0.7;
                    facility = "Hotel";
                }
                destination = "Bulgaria";
            }
            else if (budget <= 1000)
            {
                if (season == "summer")
                {
                    budget *= 0.4;
                    facility = "Camp";
                }
                else
                {
                    budget *= 0.8;
                    facility = "Hotel";
                }
                destination = "Balkans";
            }
            else
            {
                facility = "Hotel";
                budget *= 0.9;
                destination = "Europe";
            }
            
            Console.WriteLine("Somewhere in {0}", destination);
            Console.WriteLine("{0} - {1:f2}",facility,budget);
        }
    }
}
