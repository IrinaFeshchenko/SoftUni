namespace _4.Count_Symbols
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        static void Main()
        {
            string text = Console.ReadLine();
            SortedDictionary<char, int> dic = new SortedDictionary<char, int>();

            foreach (var ch in text)
            {
                if (!dic.ContainsKey(ch))
                {
                    dic.Add(ch, 1);
                }
                else
                {
                    dic[ch]++;
                }
            }

            foreach (var ch in dic)
            {
                Console.WriteLine($"{ch.Key}: {ch.Value} time/s");
            }
        }
    }
}
