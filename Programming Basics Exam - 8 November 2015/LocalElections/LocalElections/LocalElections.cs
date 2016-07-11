

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class LocalElections
    {
        static void Main()
        {
            int candidateLists = int.Parse(Console.ReadLine());
            int vote = int.Parse(Console.ReadLine());
            string votingSimbol = Console.ReadLine();


            for (int i = 1; i <= candidateLists; i++)
            {
                if (i==vote)
                {
                    if (votingSimbol.ToLower()=="v")
                    {
                        Console.WriteLine(
@".............
...+-----+...
...|\.../|...
{0:d2}.|.\./.|...
...|..V..|...
...+-----+...",i);
                    }
                    else
                    {
                        Console.WriteLine(
@".............
...+-----+...
...|.\./.|...
{0:d2}.|..X..|...
...|./.\.|...
...+-----+...",i);
                    }
                }
                else
                {
                    Console.WriteLine(
@".............
...+-----+...
...|.....|...
{0:d2}.|.....|...
...|.....|...
...+-----+...",i);
                }
            }
            Console.WriteLine(".............");
        }
    }
}
