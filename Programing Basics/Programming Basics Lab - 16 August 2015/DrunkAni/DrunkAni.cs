

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class DrunkAni
    {
        static void Main()
        {
            long numOfCabins = long.Parse(Console.ReadLine());
            string command;
            List<string> result = new List<string>();
            long totalSteps = 0;
            long currentCabin = 0;
            long nextCabin = 0;
            long nextSteps = 0;

            while ((command = Console.ReadLine()) != "Found a free one!")
            {
                long steps = long.Parse(command);
                nextCabin = (currentCabin + steps) % numOfCabins;
                nextSteps = nextCabin - currentCabin;
                currentCabin = nextCabin;

                if (nextSteps < 0)
                {
                    nextSteps *= -1;
                    result.Add(string.Format("Go {0} steps to the left, Ani.", nextSteps));
                    totalSteps += nextSteps;
                }
                else if (nextSteps == 0)
                {
                    result.Add(string.Format("Stay there, Ani."));
                }
                else
                {
                    result.Add(string.Format("Go {0} steps to the right, Ani.", nextSteps));
                    totalSteps += nextSteps;
                }
            }

            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(result[i]);
            }
            Console.WriteLine("Moved a total of {0} steps.",totalSteps);
        }
    }
}
