

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class DecrypttheMessages
    {
        static void Main()
        {
            string message;
            while ((message = Console.ReadLine()).ToLower() != "start")
            {
                ;
            }
            Dictionary<char, char> specialChars = new Dictionary<char, char>();
            specialChars.Add('+',' '); specialChars.Add('%', ','); specialChars.Add('&', '.');
            specialChars.Add('#', '?'); specialChars.Add('$', '!');
            List<string> result = new List<string>();
            while ((message = Console.ReadLine()).ToLower() != "end")
            {
                if (message!="")
                {
                    char[] msg = message.ToArray();
                    for (int i = 0; i < msg.Length; i++)
                    {
                        if ((msg[i] >= 'A' && msg[i] <= 'M') || (msg[i] >= 'a' && msg[i] <= 'm'))
                        {
                            msg[i] += (char)13;
                        }
                        else if ((msg[i] >= 'N' && msg[i] <= 'Z') || (msg[i] >= 'm' && msg[i] <= 'z'))
                        {
                            msg[i] -= (char)13;
                        }
                        else if (specialChars.ContainsKey(msg[i]))
                        {
                            msg[i] = specialChars[msg[i]];
                        }
                    }
                    Array.Reverse(msg);
                    result.Add(string.Join("", msg));
                }
            }

            if (result.Count==0)
            {
                Console.WriteLine("No message received.");
            }
            else
            {
                Console.WriteLine("Total number of messages: {0}",result.Count);
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
