

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class LighttheTorches
    {
        static void Main()
        {
            long rooms = long.Parse(Console.ReadLine());
            string ld = Console.ReadLine();
            long newPosition = 0;
            long lastPosition = rooms / 2;

            char[] room = new char[rooms];

            for (int i = 0; i < rooms; i++)
            {
                room[i] = ld[i % ld.Length];
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] param = command.Split();
                string direction = param[0];
                long steps = long.Parse(param[1]);

                if (direction == "LEFT")
                {
                    newPosition = lastPosition - (steps + 1);
                    if (newPosition < 0)
                    {
                        newPosition = 0;
                    }

                    if (lastPosition != 0)
                    {
                        if (room[newPosition] == 'L')
                        {
                            room[newPosition] = 'D';
                        }
                        else if (room[newPosition] == 'D')
                        {
                            room[newPosition] = 'L';
                        }
                    }
                    lastPosition = newPosition;
                }
                else if (direction == "RIGHT")
                {
                    newPosition = lastPosition + (steps + 1);
                    if (newPosition >= rooms)
                    {
                        newPosition = rooms - 1;
                    }

                    if (lastPosition != (rooms -1))
                    {
                        if (room[newPosition] == 'L')
                        {
                            room[newPosition] = 'D';
                        }
                        else if (room[newPosition] == 'D')
                        {
                            room[newPosition] = 'L';
                        }
                    }

                    lastPosition = newPosition;
                }
            }

            ulong countDarkRooms = 0;
            for (long i = 0; i < room.Length; i++)
            {
                if (room[i]=='D')
                {
                    countDarkRooms++;
                }
            }

            ulong result = 68 * countDarkRooms;
            Console.WriteLine(result);
        }
    }
}
