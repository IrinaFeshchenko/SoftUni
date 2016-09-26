

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class OnTimeForTheExam
    {
        static void Main()
        {
            var examHour = long.Parse(Console.ReadLine());
            var examMin = long.Parse(Console.ReadLine());
            var arriveHour = long.Parse(Console.ReadLine());
            var arriveMin = long.Parse(Console.ReadLine());

            long arriveTime = arriveHour * 60 + arriveMin;
            long examTime = examHour * 60 + examMin;

            if (arriveTime < (examTime - 30))
            {
                Console.WriteLine("Early");
            }
            else if (arriveTime > examTime)
            {
                Console.WriteLine("Late");
            }
            else
            {
                Console.WriteLine("On Time");
            }

            if (arriveTime != examTime)
            {
                if (arriveTime <= (examTime - 60))
                {
                    Console.WriteLine("{0}:{1:d2} hours before the start", (examTime - arriveTime) / 60, (examTime - arriveTime) % 60);
                }
                else if (arriveTime < examTime)
                {
                    Console.WriteLine("{0} minutes before the start", examTime - arriveTime);
                }
                else if (arriveTime < (examTime + 60))
                {
                    Console.WriteLine("{0} minutes after the start", arriveTime - examTime);
                }
                else if (arriveTime >= (examTime + 60))
                {
                    Console.WriteLine("{0}:{1:d2} hours after the start", (arriveTime - examTime) / 60, (arriveTime - examTime) % 60);
                }
            }
        }
    }
}
