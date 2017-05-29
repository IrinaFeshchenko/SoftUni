namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Text.RegularExpressions;

    public class Start
    {
        public static void Main()
        {
            string inputWords = "words.txt";
            string inputText = "text.txt";
            string output = "output.txt";

            string text = File.ReadAllText(inputText).ToLower();
            string[] searchWords = File.ReadAllText(inputWords).ToLower().Split(' ');

            string[] words = text.Split(new[] { '\n', '\r', ' ', '.', ',', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (searchWords.Contains(word))
                {
                    if (!wordsCount.ContainsKey(word))
                    {
                        wordsCount.Add(word, 0);
                    }

                    wordsCount[word]++;
                }
            }

            var result = wordsCount
                        .OrderByDescending(x => x.Value)
                        .Select(x => $"{x.Key} - {x.Value}");

            File.WriteAllLines(output, result);
        }
    }
}
