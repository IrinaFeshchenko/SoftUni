

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ExamSchedule
    {
        static void Main()
        {
            int startH = int.Parse(Console.ReadLine());
            int startM = int.Parse(Console.ReadLine());
            string startDayPart = Console.ReadLine();
            int durH = int.Parse(Console.ReadLine());
            int durM = int.Parse(Console.ReadLine());

            decimal dayPart = 0;
            if (startDayPart=="PM")
            {
                dayPart = 12 * 60;
            }
            decimal startMin = startH * 60 + startM + dayPart;
            decimal durationMin = durH * 60 + durM;

            decimal endMin = startMin + durationMin;
            if (endMin>= (24*60))
            {
                endMin %= (24 * 60);
            }

            string endDayPart = "AM";
            if (endMin >= 12*60)
            {
                endDayPart = "PM";
                endMin %= 12 * 60;
            }

            Console.WriteLine("{0:00}:{1:00}:{2}", ((int)endMin / 60)==0?12:(int)endMin/60, (int)endMin %60,endDayPart);
        }
    }
}
