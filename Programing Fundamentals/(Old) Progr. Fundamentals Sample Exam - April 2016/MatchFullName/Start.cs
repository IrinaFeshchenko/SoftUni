namespace MatchFullName
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Start
    {
        public static void Main()
        {
            Regex rg = new Regex("([A-Z][a-z]+ [A-Z][a-z]+)");

            while (true)
            {
                string text = Console.ReadLine();
                if (text == "end")
                {
                    break;
                }

                Match match = rg.Match(text);
                Console.WriteLine(match);
            }
        }
    }
}
