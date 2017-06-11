namespace _09.Text_Filter
{
    using System;
    using System.Text;

    public class Startup
    {
        static void Main()
        {
            string[] words = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder text = new StringBuilder(Console.ReadLine());

            foreach (var word in words)
            {
                string replacementWord = new string('*', word.Length);
                text.Replace(word, replacementWord);
            }

            Console.WriteLine(text.ToString());
        }
    }
}
