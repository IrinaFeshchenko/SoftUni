namespace TextFilter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Start
    {
        static void Main()
        {
            string[] words = Console.ReadLine().Split(new[] { ' ',',' }, StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            StringBuilder sbText = new StringBuilder();
            sbText.Append(text);

            foreach (var word in words)
            {
                string replacementWord = new string('*',word.Length);
                sbText.Replace(word,replacementWord);
            }

            Console.WriteLine(sbText.ToString());
        }
    }
}
