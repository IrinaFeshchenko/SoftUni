namespace UnicodeCharacters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Start
    {
        public static void Main()
        {
            string s = Console.ReadLine();

            string result=string.Empty;

            foreach (var ch in s)
            {
                result += $"\\u{(int)ch:x4}";
            }

            Console.WriteLine(result);
        }
    }
}
