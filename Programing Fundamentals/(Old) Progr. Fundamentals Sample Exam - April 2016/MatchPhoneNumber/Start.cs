

namespace MatchPhoneNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Start
    {
        static void Main()
        {
            Regex rg = new Regex(@"^\+359( |-)2\1\d{3}\1\d{4}$");

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                Match match = rg.Match(line);
                Console.WriteLine(match);
            }
        }
    }
}
