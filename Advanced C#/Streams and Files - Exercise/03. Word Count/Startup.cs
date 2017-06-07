//Write a program that reads a list of words from the file words.txt and finds how many times each of the words is contained in another file text.txt.Matching should be case-insensitive.
//Write the results in file results.txt.Sort the words by frequency in descending order. Use StreamReader in combination with StreamWriter.

namespace _03.Word_Count
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class Startup
    {
        static void Main()
        {
            using (StreamReader wordsReader = new StreamReader("../../words.txt"))
            {
                using (StreamReader textReader = new StreamReader("../../text.txt"))
                {
                    using (StreamWriter resultWriter = new StreamWriter("../../result.txt"))
                    {
                        string line = string.Empty;
                        List<string> words = new List<string>();
                        StringBuilder text = new StringBuilder();

                        // read all words from first file
                        while ((line = wordsReader.ReadLine()) != null)
                        {
                            words.Add(line.Trim());
                        }

                        // read the text from second file
                        while ((line = textReader.ReadLine()) != null)
                        {
                            text.Append(line);
                        }

                        //Convert the text into an array of words and count the one that mach the words from the first file
                        var wordsOccuranceCounts = text.ToString()
                                           .Split(new char[] { '-','.', '?', '!', ' ', ';', ':', ',' },
                                           StringSplitOptions.RemoveEmptyEntries)
                                           .GroupBy(w => w, StringComparer.InvariantCultureIgnoreCase)
                                           .Where(w => words.Contains(w.Key, StringComparer.InvariantCultureIgnoreCase))
                                           .ToDictionary(g => g.Key, g => g.Count());

                        // write the result to the third text file
                        foreach (var word in wordsOccuranceCounts)
                        {
                            resultWriter.WriteLine($"{word.Key} - {word.Value}");
                        }
                    }
                }
            }
        }
    }
}
