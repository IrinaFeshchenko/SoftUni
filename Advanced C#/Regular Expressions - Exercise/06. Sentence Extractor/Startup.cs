namespace _06.Sentence_Extractor
{
    using System;    using System.Text.RegularExpressions;

    public class Startup    {        public static void Main()        {            string keyword = Console.ReadLine();
            string input = Console.ReadLine();

            Regex regex = new Regex($"[^\\.!\\?]*\\b{keyword}\\b[^\\.!\\?]*(\\.|!|\\?)");

            var matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }    }
}
