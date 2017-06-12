namespace _05.Extract_Tags
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string text = ReadInput();

            string pattern = "<.+?>";

            var matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);

            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
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
