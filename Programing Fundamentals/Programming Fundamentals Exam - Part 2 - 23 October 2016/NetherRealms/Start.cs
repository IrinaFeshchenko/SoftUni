namespace NetherRealms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Start
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string[] args = input.Split(new[] { ' ',',' }, StringSplitOptions.RemoveEmptyEntries);
            char[] skipLetters = "0123456789+-*/.".ToCharArray();
            List<string> result = new List<string>();

            foreach (var dragonName in args)
            {
                long lettersSum = 0;

                foreach (var letter in dragonName)
                {
                    if(!skipLetters.Contains(letter))
                    {
                        lettersSum += (long)letter;
                    }
                }

                string numbersPattern = @"(-?\d*\.?\d+)";
                var numbersMatches = Regex.Matches(dragonName,numbersPattern);

                decimal numbersSum = 0;
                foreach (Match numberMatch in numbersMatches)
                {
                    numbersSum += decimal.Parse(numberMatch.Groups[1].Value);
                }

                foreach (var letter in dragonName)
                {
                    if (letter == '*')
                    {
                        numbersSum *= 2;
                    }
                    if (letter == '/')
                    {
                        numbersSum /= 2;
                    }
                }

                result.Add($"{dragonName} - {lettersSum} health, {numbersSum:f2} damage");
            }

            var sortedResult = result.OrderBy(x=>x);

            foreach (var dragonInfo in sortedResult)
            {
                Console.WriteLine(dragonInfo);
            }
        }
    }
}
