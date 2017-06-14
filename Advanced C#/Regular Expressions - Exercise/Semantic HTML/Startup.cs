namespace Semantic_HTML
{
    using System;    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Startup    {        public static void Main()        {
            List<string> html = new List<string>();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "END") break;

                Regex regexOpenTag = new Regex(@"<\s*div([^>]*?)((?:id|class)\s*=\s*""([^ ""]+)"")(.*?)>");
                Regex regexCloseTag = new Regex(@"<\/div>\s*<!--\s*([a-z]*?)\s*-->");
                Regex regexCleareEndWhitespace = new Regex(@"\s+>");
                Regex regexSpacing = new Regex(@"\s+");

                if (regexOpenTag.IsMatch(line))
                {
                    line = regexOpenTag.Replace(line, "<$3 $1 $4>");
                    line = regexCleareEndWhitespace.Replace(line,">");
                    line = regexSpacing.Replace(line," ");
                }
                else if (regexCloseTag.IsMatch(line))
                {
                    line = regexCloseTag.Replace(line, "</$1>");
                }

                html.Add(line);
            }            foreach (var line in html)
            {
                Console.WriteLine(line);
            }        }    }
}
