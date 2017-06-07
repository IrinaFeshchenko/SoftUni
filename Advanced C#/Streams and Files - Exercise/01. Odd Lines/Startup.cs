namespace _01.Odd_Lines
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Startup
    {
        static void Main()
        {
            StreamReader reader = new StreamReader("../../text.txt");

            using (reader)
            {
                int lineNumber = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (lineNumber%2!=0)
                    {
                        Console.WriteLine(line);
                    }
                    lineNumber++;
                }
            }
        }
    }
}
