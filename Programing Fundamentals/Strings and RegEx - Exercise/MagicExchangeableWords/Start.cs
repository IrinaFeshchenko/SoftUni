namespace MagicExchangeableWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Start
    {
        public static void Main()
        {
            string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string s1 = args[0];
            string s2 = args[1];

            bool result = AreExchangeable(s1, s2);
            if (result)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }

        private static bool AreExchangeable(string s1, string s2)
        {
            bool areExchangeable = true;
            Dictionary<char, char> map = new Dictionary<char, char>();

            if (s1.Length < s2.Length)
            {
                string s = s1;
                s1 = s2;
                s2 = s;
            }

            for (int i = 0; i < Math.Min(s1.Length, s2.Length); i++)
            {
                if (!map.ContainsKey(s1[i]))
                {
                    map.Add(s1[i], s2[i]);
                }
                else
                {
                    if (map[s1[i]] != s2[i])
                    {
                        areExchangeable = false;
                        break;
                    }
                }
            }

            for (int i = s2.Length; i < s1.Length; i++)
            {
                if (!map.ContainsKey(s1[i]))
                {
                    areExchangeable = false;
                    break;
                }
            }

            return areExchangeable;
        }
    }
}
