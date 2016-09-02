using System;

public class Substring_broken
{
    public static void Main()
    {
        string text = Console.ReadLine();
        int jump = int.Parse(Console.ReadLine().Trim());

        const char Search = 'p';
        bool hasMatch = false;

        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];
            if (c == Search)
            {
                hasMatch = true;

                int endIndex = i + jump+1;

                if (endIndex >= text.Length)
                {
                    endIndex = text.Length-1;
                    jump = endIndex - i;
                }

                string matchedString = text.Substring(i, jump+1);
                Console.WriteLine(matchedString);
                i += jump;
            }
        }

        if (!hasMatch)
        {
            Console.WriteLine("no");
        }
    }
}
