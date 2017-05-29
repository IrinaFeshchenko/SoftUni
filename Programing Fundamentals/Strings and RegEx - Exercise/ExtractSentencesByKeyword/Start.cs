namespace ExtractSentencesByKeyword
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Start
    {
        public static void Main()
        {
            char[] sentencesSeparator = ".!?".ToCharArray();

            string keyword = Console.ReadLine();
            string text = Console.ReadLine();
            string[] sentences = text.Split(sentencesSeparator);

            List<string> result = new List<string>();
            foreach (var sentence in sentences)
            {
                string pattern = $"\\W{keyword}\\W";

                if (Regex.IsMatch(sentence,pattern))
                {
                    result.Add(sentence.Trim());
                }
            }

            foreach (var sentence in result)
            {
                Console.WriteLine(sentence);
            }
        }
    }
}
