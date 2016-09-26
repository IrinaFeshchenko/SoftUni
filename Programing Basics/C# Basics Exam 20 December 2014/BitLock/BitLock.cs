


namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BitLock
    {
        static void Main()
        {
            uint[] number = Console.ReadLine().Split()
                .Select(uint.Parse)
                .ToArray();

            int height = 8;
            int width = 12;
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] param = command.Split();
                if (param[0] == "check")
                {
                    int col = int.Parse(param[1]);
                    int count = 0;
                    for (int i = 0; i < height; i++)
                    {
                        if (((number[i] >> col) & 1) == 1)
                        {
                            count++;
                        }
                    }
                    Console.WriteLine(count);
                }
                else
                {
                    int row = int.Parse(param[0]);
                    string direction = param[1];
                    int rotation = int.Parse(param[2]);

                    if (direction == "left")
                    {
                        for (int i = 0; i < rotation; i++)
                        {

                            number[row] <<= 1;
                            number[row] |= (number[row] >> width & 1);
                            number[row] &= ~(1u << width);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < rotation; i++)
                        {
                            uint bit = number[row] & 1;
                            number[row] >>= 1;
                            number[row] |= (bit << width - 1);
                        }
                    }

                }

            }

            Console.WriteLine(string.Join(" ",number));
        }
    }
}
