

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ConvertSpeedUnits
    {
        static void Main()
        {
            float distanceInMeters = float.Parse(Console.ReadLine());
            float hours = float.Parse(Console.ReadLine());
            float minutes = float.Parse(Console.ReadLine());
            float seconds = float.Parse(Console.ReadLine());

            float timeInSeconds = (hours * 3600f) + (minutes * 60f) + seconds;
            float mps = distanceInMeters / timeInSeconds;
            Console.WriteLine(mps);

            float timeInHours = ((seconds / 3600f) + (minutes / 60f) + hours);
            float distanceKm = distanceInMeters / 1000f;
            float kmh = distanceKm / timeInHours;
            Console.WriteLine(kmh);

            float mih = kmh / 1.609f;
            Console.WriteLine(mih);
        }
    }
}
