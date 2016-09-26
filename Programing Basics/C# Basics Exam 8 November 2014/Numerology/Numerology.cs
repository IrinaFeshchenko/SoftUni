

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Numerology
    {
        static void Main()
        {
            string s = Console.ReadLine().Trim();
            string[] param =  s.Split();
            string[] date = param[0].Split('.');
            string name = param[1];

            int day = int.Parse(date[0]);
            int month = int.Parse(date[1]);
            int year = int.Parse(date[2]);

            long result = day * month * year;

            if (month%2!=0)
            {
                result *= result;
            }

            for (int i = 0; i < name.Length; i++)
            {
                if (char.IsDigit(name[i]))
                {
                    result += name[i] - '0';
                }
                else if (char.IsLower(name[i]))
                {
                    result += name[i] - 'a' + 1;
                }
                else if (char.IsUpper(name[i]))
                {
                    int j = (name[i] - 'A' + 1);
                    result += j*2;
                }
            }

            while (result>13)
            {
                int i = 0;
                foreach (var ch in result.ToString())
                {
                    i += ch - '0';
                }
                result = i;
            }
            Console.WriteLine(result);
        }
    }
}
