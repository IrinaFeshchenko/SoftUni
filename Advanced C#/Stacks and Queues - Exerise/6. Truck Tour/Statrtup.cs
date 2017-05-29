//Suppose there is a circle.There are N petrol pumps on that circle.Petrol pumps are numbered 0 to (N−1) (both inclusive). You have two pieces of information corresponding to each of the petrol pump: (1) the amount of petrol that particular petrol pump will give, and (2) the distance from that petrol pump to the next petrol pump.
//Initially, you have a tank of infinite capacity carrying no petrol.You can start the tour at any of the petrol pumps.Calculate the first point from where the truck will be able to complete the circle.Consider that the truck will stop at each of the petrol pumps.The truck will move one kilometer for each liter of the petrol.
//Input Format: The first line will contain the value of N.
//The next N lines will contain a pair of integers each, i.e.the amount of petrol that petrol pump will give and the distance between that petrol pump and the next petrol pump.
//Output Format: An integer which will be the smallest index of the petrol pump from which we can start the tour.
//Constraints: 
//1 ≤ N ≤ 1000001
//1 ≤ Amount of petrol, Distance ≤ 1000000000
//Examples
//Input   Output
//3
//1 5
//10 3
//3 4       1

namespace _6.Truck_Tour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            long pumps = int.Parse(Console.ReadLine());

            Queue<long> q = new Queue<long>();

            for (int i = 0; i < pumps; i++)
            {
                long[] args = Console.ReadLine()
                                     .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(long.Parse)
                                     .ToArray();

                long liters = args[0];
                long distance = args[1];
                q.Enqueue(liters - distance);
            }


            for (int i = 0; i < pumps; i++)
            {
                bool success = true;
                long truck = 0;
                foreach (var p in q)
                {
                    truck += p;
                    if (truck<0)
                    {
                        success = false;
                        break;
                    }
                }

                if (success)
                {
                    Console.WriteLine(i);
                    break;
                }
                else
                {
                    q.Enqueue(q.Dequeue());
                }  
            }
        }
    }
}
