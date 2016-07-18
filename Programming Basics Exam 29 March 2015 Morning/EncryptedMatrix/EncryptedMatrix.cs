

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class EncryptedMatrix
    {
        static void Main()
        {
            string message = Console.ReadLine();
            char direction = char.Parse(Console.ReadLine());

            List<int> number = new List<int>();
            for (int i = 0; i < message.Length; i++)
            {
                int num = message[i];
                number.Add(num % 10);
            }

            List<int> encriptedNumber = new List<int>(number);
            int length = number.Count;
            for (int i = 0; i < length; i++)
            {
                if (number[i] % 2 == 0)
                {
                    encriptedNumber[i] = number[i] * number[i];
                }
                else if (number[i] % 2 != 0)
                {
                    if ((length - 1) == 0)
                    {
                        continue;
                    }
                    else if (i == 0)
                    {
                        encriptedNumber[i] = number[i] + number[i + 1];
                    }
                    else if (i == length - 1)
                    {
                        encriptedNumber[i] = number[i] + number[i - 1];
                    }
                    else
                    {
                        encriptedNumber[i] = number[i] + number[i + 1] + number[i - 1];
                    }
                }
            }

            List<int> result = new List<int>();
            length = encriptedNumber.Count;
            for (int i = 0; i < length; i++)
            {
                char[] c = encriptedNumber[i].ToString().ToCharArray();
                for (int j = 0; j < c.Length; j++)
                {
                    result.Add(c[j] - '0');
                }
            }

            length = result.Count;
            if (direction == '\\')
            {
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        if (i == j)
                        {
                            Console.Write("{0} ", result[i]);
                        }
                        else
                        {
                            Console.Write("0 ");
                        }

                    }
                    Console.WriteLine();
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        if (i == (length - j - 1))
                        {
                            Console.Write("{0} ", result[length - i - 1]);
                        }
                        else
                        {
                            Console.Write("0 ");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}