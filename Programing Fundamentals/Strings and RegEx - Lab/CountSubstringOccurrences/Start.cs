namespace CountSubstringOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Start
    {
        static void Main()
        {
            string text = Console.ReadLine();
            string pattern = Console.ReadLine();

            int currentIndex = 0;
            int count = 0;
            while (true)
            {
                var index = text.IndexOf(pattern,currentIndex, StringComparison.OrdinalIgnoreCase);
                if (index == -1)
                {
                    break;
                }
                else
                {
                    count++;
                }

                currentIndex = index+1;
            }

            Console.WriteLine(count);
        }
    }
}
