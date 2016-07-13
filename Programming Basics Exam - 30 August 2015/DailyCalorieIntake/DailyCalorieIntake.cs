

namespace Namespace
{
    using System;

    class DailyCalorieIntake
    {
        static void Main()
        {
            double weight = double.Parse(Console.ReadLine()) / 2.2d;
            double height = double.Parse(Console.ReadLine()) * 2.54d;

            double age = double.Parse(Console.ReadLine());
            char gender = char.Parse(Console.ReadLine());
            long workouts = long.Parse(Console.ReadLine());

            double bmr = 0;
            if (gender == 'm')
            {
                bmr = 66.5d + (13.75d * weight) + (5.003d * height) - (6.755d * age);
            }
            else
            {
                bmr = 655d + (9.563d * weight) + (1.850d * height) - (4.676d * age);
            }

            double dci = 0;
            if (workouts <= 0)
            {
                dci = bmr * 1.2d;
            }
            else if (workouts<=3)
            {
                dci = bmr * 1.375d;
            }
            else if (workouts <= 6)
            {
                dci = bmr * 1.55d;
            }
            else if (workouts <= 9)
            {
                dci = bmr * 1.725d;
            }
            else
            {
                dci = bmr * 1.9d;
            }

            Console.WriteLine(Math.Floor(dci));
        }
    }
}
