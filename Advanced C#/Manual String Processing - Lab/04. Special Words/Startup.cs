namespace _04.Special_Words
{
    using Microsoft.CSharp;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class Startup
    {
        static void Main()
        {
            var wordSeparators = "()[]<>,-!? ".ToCharArray();

            var specialWords = Read().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList().ToDictionary(w => w, w=>0);

            var textWords = Read().Split(wordSeparators, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in textWords)
            {
                if (specialWords.ContainsKey(word))
                {
                    specialWords[word]++;
                }
            }

            foreach (var word in specialWords)
            {
                Console.WriteLine($"{word.Key} - {word.Value} ");
            }
        }

        static string Read()
        {
            //return Mock.ReadLine();
            return Console.ReadLine();
        }

        public static class Mock
        {
            static List<string> lines =
 @".NET Microsoft run
.NET Framework (pronounced dot net) is a software framework developed by Microsoft that runs primarily on Microsoft Windows.
"
.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();

            static int lineNumber = 0;

            public static string ReadLine()
            {
                string line = lines[lineNumber++];
                return line;
            }
        }
    }
}
