namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            bool isRunning = true;
            IList<IBornable> subjects = new List<IBornable>();

            while (isRunning)
            {
                IList<string> args = Console.ReadLine().Split().ToList();

                string command = args[0];
                args.RemoveAt(0);

                if (command == "End")
                {
                    isRunning = false;
                }
                else if (command == "Pet")
                {
                        subjects.Add(new Pet(args[0], args[1]));
                }
                else if (command == "Citizen")
                {
                    subjects.Add(new Citizen(args[0], int.Parse(args[1]), args[2], args[3]));
                }
            }

            string year = Console.ReadLine();

            if (subjects.Any())
            {
                foreach (var subject in subjects)
                {
                    if (Regex.IsMatch(subject.Birthdate, $"{year}$"))
                    {
                        Console.WriteLine(subject.Birthdate);
                    }
                }
            }
            else
            {
               // Console.WriteLine("<empty output>");
            }
        }
    }
}
