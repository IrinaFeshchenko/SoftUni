

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ProgramPerfectGirlfriend
    {
        static void Main()
        {
            Dictionary<string, int> day = new Dictionary<string, int>()
            {
                {"Monday",1 },{"Tuesday",2 },{"Wednesday",3 },{"Thursday",4},{"Friday",5 },{"Saturday",6 },{"Sunday",7 }
            };

            string input;
            List<string> output = new List<string>();
            int matches = 0;
            while ((input = Console.ReadLine()) != "Enough dates!")
            {
                string[] param = input.Split('\\');
                string dayOfWeek = param[0];
                string phoneNumber = param[1];
                string braSize = param[2];
                string girlName = param[3];
                int magicNumber = 6000;
                int dayDigit = day[dayOfWeek];
                int phoneDigit = 0;

                for (int i = 0; i < phoneNumber.Length; i++)
                {
                    phoneDigit += phoneNumber[i] - '0';
                }
                int braDigit = int.Parse(braSize.Substring(0, braSize.Length - 1)) * braSize[braSize.Length-1];
                int nameDigit = girlName[0] * girlName.Length;

                int result = dayDigit + phoneDigit + braDigit - nameDigit;

                if (result >= magicNumber)
                {
                    output.Add(string.Format("{0} is perfect for you.", girlName));
                    matches++;
                }
                else
                {
                    output.Add(string.Format("Keep searching, {0} is not for you.", girlName));
                }
            }

            for (int i = 0; i < output.Count; i++)
            {
                Console.WriteLine(output[i]);
            }
            Console.WriteLine(matches);
        }
    }
}
