

namespace TheaThePhotographer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Start
    {
        public static void Main()
        {
            int pictures = int.Parse(Console.ReadLine());
            double ft = int.Parse(Console.ReadLine());
            int percentUseful = int.Parse(Console.ReadLine());
            int ut = int.Parse(Console.ReadLine());

            double filteredPics = Math.Ceiling(pictures * (percentUseful / 100.0));

            double timeToTake = pictures * ft;
            double timeToUpload = filteredPics * ut;

            double totalTime = timeToTake + timeToUpload;

            DateTime dt = new DateTime();
            DateTime dt1 = new DateTime().AddSeconds(totalTime);
            TimeSpan time = dt1 - dt;

            Console.WriteLine($"{time.Days:d1}:{time.Hours:d2}:{time.Minutes:d2}:{time.Seconds:d2}");
        }
    }
}
