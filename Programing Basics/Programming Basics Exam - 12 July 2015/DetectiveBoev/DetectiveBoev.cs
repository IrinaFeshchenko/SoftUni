

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    class DetectiveBoev
    {
        static void Main()
        {
            string word = Console.ReadLine().Trim();
            char[] message = Console.ReadLine().Trim().ToArray();        

            int sum = 0;
            for (int i = 0; i < word.Length; i++)
            {
                sum += word[i];
            }

            string stringMask = sum.ToString();
            while (stringMask.Length>1)
            {
                int buffer = 0;
                for (int i = 0; i < stringMask.Length; i++)
                {
                    buffer += stringMask[i] - '0';
                }
                stringMask = buffer.ToString();
            }

            int mask = int.Parse(stringMask);
            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] % mask == 0)
                {
                    message[i] += (char) mask; 
                }
                else
                {
                    message[i] -= (char)mask;
                }
            }
            message = message.Reverse().ToArray();
            Console.WriteLine(message);
        }
    }
}
