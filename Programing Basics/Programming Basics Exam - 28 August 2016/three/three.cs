

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class three
    {
        static void Main()
        {
            string month = Console.ReadLine();
            decimal nightsCount = int.Parse(Console.ReadLine());

            decimal studioPerNight = 0;
            decimal apartmentPerNight = 0;

            if (month == "May" || month == "October")
            {
                studioPerNight = 50m;
                apartmentPerNight = 65m;
            }
            else if (month == "June" || month == "September")
            {
                studioPerNight = 75.20m;
                apartmentPerNight = 68.70m;
            }
            else if (month == "July" || month == "August")
            {
                studioPerNight = 76m;
                apartmentPerNight = 77m;
            }

            decimal totalApartmentPrice = nightsCount * apartmentPerNight;
            decimal totalStufioPrice = nightsCount * studioPerNight;

            if (nightsCount>7 && nightsCount <= 14 &&
                    (month == "May" || month == "October"))
            {
                totalStufioPrice *= 0.95m;
            }
            else if (nightsCount > 14 &&
                    (month == "May" || month == "October"))
            {
                totalStufioPrice *= 0.70m;
            }
            else if (nightsCount > 14 &&
                    (month == "June" || month == "September"))
            {
                totalStufioPrice *= 0.80m;
            }

            if (nightsCount>14)
            {
                totalApartmentPrice *= 0.90m;
            }

            Console.WriteLine($"Apartment: {totalApartmentPrice:f2} lv.");
            Console.WriteLine($"Studio: {totalStufioPrice:f2} lv.");
        }
    }
}
