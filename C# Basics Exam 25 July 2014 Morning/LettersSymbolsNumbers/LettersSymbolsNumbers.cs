

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class LettersSymbolsNumbers
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            char[] symbols = "`~!@#$%^&*()_+{}:\" |<>?-=[]; '\\,./".ToCharArray();

            long lettersSum = 0, symbolsSum = 0, numbersSum = 0;
            for (int i = 0; i < n; i++)
            {
                string s = Console.ReadLine().Trim().ToLower();

                for (int j = 0; j < s.Length; j++)
                {
                    if (char.IsWhiteSpace(s[j]))
                    {
                        continue;
                    }
                    else if (symbols.Contains(s[j]))
                    {
                        symbolsSum += 200;
                    }
                    else if (char.IsLetter(s[j]))
                    {
                        lettersSum += (s[j] - 'a'+1)*10;
                    }
                    else if (char.IsNumber(s[j]))
                    {
                        numbersSum += (s[j] - '0') * 20;
                    }
                }
            }
            Console.WriteLine(lettersSum);
            Console.WriteLine(numbersSum);
            Console.WriteLine(symbolsSum);
        }
    }
}
