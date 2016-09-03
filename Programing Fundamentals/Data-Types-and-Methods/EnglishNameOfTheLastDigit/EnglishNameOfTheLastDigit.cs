

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class EnglishNameOfTheLastDigit
    {
        private static Dictionary<decimal, string> digitToWord = new Dictionary<decimal, string>()
        {
            { 0,"zero"},
            { 1,"one"},
            { 2,"two"},
            { 3,"three"},
            { 4,"four"},
            { 5,"five"},
            { 6,"six"},
            { 7,"seven"},
            { 8,"eight"},
            { 9,"nine"},
        };

        static void Main()
        {
            string s = Console.ReadLine();
            string lastDigit = LastDigitToEnglish(s);

            Console.WriteLine(lastDigit);
        }

        private static string LastDigitToEnglish(string s)
        {
            int lastDigit = s[s.Length-1] - '0';

            return digitToWord[lastDigit];
        }

        
    }
}
