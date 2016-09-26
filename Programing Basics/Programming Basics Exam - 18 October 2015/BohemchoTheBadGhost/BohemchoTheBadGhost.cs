

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BohemchoTheBadGhost
    {
        static void Main()
        {
            string command;
            ulong totalLights = 0;
            ulong totalScores = 0;

            while ((command = Console.ReadLine()) != "Stop, God damn it")
            {
                ulong floor = ulong.Parse(command);
                int[] lights = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToArray();

                for (int i = 0; i < lights.Length; i++)
                {
                    floor ^= ((ulong)1 << lights[i]);
                }

                ulong lightsOn = 0;
                for (int i = (64 - 1); i >= 0; i--)
                {
                    lightsOn += (floor >> i) & 1;
                }

                totalLights += lightsOn;
                totalScores += floor;
            }

            Console.WriteLine("Bohemcho left {0} lights on and his score is {1}", totalLights, totalScores);
        }
    }
}
