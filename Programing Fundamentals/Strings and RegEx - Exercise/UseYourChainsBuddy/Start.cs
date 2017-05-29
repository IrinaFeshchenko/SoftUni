namespace UseYourChainsBuddy
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
            //string text = "<html><head><title></title></head><body><h1>Intro</h1><ul><li>Item01</li><li>Item02</li><li>Item03</li></ul><p>jura qevivat va jrg fyvccrel fabjl</p><div><button>Click me, baby!</button></div><p> pbaqvgvbaf fabj  qpunvaf ner nofbyhgryl rffragvny sbe fnsr unaqyvat nygubhtu fabj punvaf znl ybbx </p><span>This manual is false, do not trust it! The illuminati wrote it down to trick you!</span><p>vagvzvqngvat gur onfvp vqrn vf ernyyl fvzcyr svg gurz bire lbhe gverf qevir sbejneq fybjyl naq gvtugra gurz hc va pbyq jrg</p><p> pbaqvgvbaf guvf vf rnfvre fnvq guna qbar ohg vs lbh chg ba lbhe gverf</p></body>";
            string text = Console.ReadLine();
            string pattern = @"<p>(.+?)<\/p>";
            var tags = Regex.Matches(text, pattern);

            StringBuilder sb = new StringBuilder();

            foreach (Match t in tags)
            {
                sb.Append(t.Groups[1].ToString());
            }

            char[] line = Regex.Replace(sb.ToString(), @"[^a-z0-9]", " ").ToCharArray();

            for (int i = 0; i < line.Length; i++)
            {
                if (!char.IsDigit(line[i]))
                {
                    if (line[i] >= 'a' && line[i] <= 'm')
                    {
                        line[i] += (char)13;
                    }
                    else if (line[i] >= 'n' && line[i] <= 'z')
                    {
                        line[i] -= (char)13;
                    }
                }
            }

            string result = Regex.Replace(string.Join("", line), @"\s+", " ").Trim();
            Console.WriteLine(result);
        }
    }
}
