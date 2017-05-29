namespace ReplaceTag
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Start
    {
        public static void Main()
        {
            StringBuilder text = new StringBuilder();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                    break;
                text.AppendLine(line);
            }

            string pattern = @"<a.*?href\s*=(?<one>.*?)>(?<two>.*?)<\/a>";
            string replacement = "[URL href=${one}]${two}[/URL]";
            var txt = text.ToString();
            var result = Regex.Replace(txt, pattern, replacement);

            Console.WriteLine(result);
        }
    }
}
