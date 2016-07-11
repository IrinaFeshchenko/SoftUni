

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SudokuResults
    {
        static void Main()
        {
            string input;
            long totalSeconds = 0;
            int games=0;
            while ((input = Console.ReadLine()) != "Quit")
            {
                games++;
                string[] param = input.Split(':');
                int minute = int.Parse(param[0]);
                int seconds = int.Parse(param[1]);

                totalSeconds += minute * 60 + seconds;
            }

            long averageSeconds = (long)Math.Ceiling((double)totalSeconds / games);

            string star;
            if (averageSeconds<720)
            {
                star = "Gold Star";
            }
            else if (averageSeconds <= 1440)
            {
                star = "Silver Star";
            }
            else
            {
                star = "Bronze Star";
            }

            Console.WriteLine(star);
            Console.WriteLine("Games - {0} \\ Average seconds - {1}",games,averageSeconds);
        }
    }
}
