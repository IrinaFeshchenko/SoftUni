

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class EncrypttheMessages
    {
        static void Main()
        {
            Dictionary<char, char> spCh = new Dictionary<char, char>();
            spCh.Add(' ','+'); spCh.Add(',', '%'); spCh.Add('.', '&');
            spCh.Add('?', '#'); spCh.Add('!', '$');
            string message;

            while ((message = Console.ReadLine().ToLower()) != "start")
            {
                ;
            }

            int msgCount = 0;
            List<string> result = new List<string>();
            while ((message = Console.ReadLine()).ToLower() != "end")
            {
                if (message != "")
                {
                    msgCount++;
                    char[] msg = message.ToArray();
                    for (int i = 0; i < msg.Length; i++)
                    {
                        if (char.IsLetter(msg[i]))
                        {
                            if ((msg[i] >= 'A' && msg[i] <= 'M')|| (msg[i] >= 'a' && msg[i] <= 'm'))
                            {
                                msg[i] = (char)(msg[i]+13);
                            }
                            else if ((msg[i] >= 'N' && msg[i] <= 'Z')|| (msg[i] >= 'n' && msg[i] <= 'z'))
                            {
                                msg[i] = (char)(msg[i] - 13);
                            }
                        }
                        else if (spCh.ContainsKey(msg[i]))
                        {
                            msg[i] = spCh[msg[i]];
                        }
                    }

                    Array.Reverse(msg);
                    result.Add(string.Join("",msg));
                }
            }

            if (msgCount == 0)
            {
                Console.WriteLine("No messages sent.");
            }
            else
            {
                Console.WriteLine("Total number of messages: {0}",msgCount);
                for (int i = 0; i < result.Count; i++)
                {
                    Console.WriteLine(result[i]);
                }
            }

        }
    }
}
