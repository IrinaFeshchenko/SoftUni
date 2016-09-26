

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RandomizeWords
    {
        static void Main()
        {
            string[] words = Console.ReadLine().Split();
            Randomize(words);
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }

        static void Randomize(string[] words)
        {
            Random rnd = new Random();
            for (int i = 0; i < words.Length; i++)
            {
                int randomPosition = rnd.Next(0, words.Length);
                SwapWords(words, i, randomPosition);
            }
        }

        static void SwapWords(string[] words, int first, int second)
        {
            string placeholder = words[first];
            words[first] = words[second];
            words[second] = placeholder;
        }
    }
}

