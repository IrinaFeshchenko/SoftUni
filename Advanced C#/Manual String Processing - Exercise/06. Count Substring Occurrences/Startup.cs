namespace _06.Count_Substring_Occurrences
{
    using System;

    public class Startup
    {
        static void Main()
        {
            string text = Console.ReadLine();
            string word = Console.ReadLine();

            int index = 0;
            int count = 0;

            while ((index = text.IndexOf(word, index,StringComparison.CurrentCultureIgnoreCase)) != -1)
            {
                count++;
                index++;
            }

            Console.WriteLine(count);
        }
    }
}
