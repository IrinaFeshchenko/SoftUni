
namespace _08.Extract_Hyperlinks
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;


    public class Startup
    {
        static void Main()
        {
            string text = ReadInput();
            List<string> links = GetAllLinks(text);

            List<string> content = new List<string>();
            foreach (var href in links)
            {
                string result = ParseHref(href);

                if (result != null)
                {
                    content.Add(result);
                }
            }

            foreach (var item in content)
            {
                Console.WriteLine(item);
            }
        }

        private static string ParseHref(string href)
        {
            string result = string.Empty;

            if (href.Contains("<"))
            {
                result = null;
            }
            else if (href[0] == '"')
            {
                result = href.Split(new[] { '\"' }, StringSplitOptions.RemoveEmptyEntries)[0];
            }
            else if (href[0] == '\'')
            {
                result = href.Split(new[] { '\'' }, StringSplitOptions.RemoveEmptyEntries)[0];
            }
            else
            {
                result = href.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];
            }

            return result;
        }


        private static List<string> GetAllLinks(string text)
        {
            List<string> links = new List<string>();
            string pattern = @"<a[^>]*?href\s*=\s*(.*?)>";

            var matches = Regex.Matches(text, pattern);

            foreach (Match match in matches)
            {
                links.Add(match.Groups[1].Value);
            }

            return links;
        }

        private static string ReadInput()
        {
            StringBuilder text = new StringBuilder();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                text.Append(input);
            }

            return text.ToString();
        }
    }
}
