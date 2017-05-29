namespace _6.Math_Potato
{
    using System;
    using System.Collections.Generic;

    class Startup
    {
        static void Main()
        {
            string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(Console.ReadLine());
            Queue<string> names = new Queue<string>(args);

            int cycle = 1;
            while (names.Count > 1)
            {
                for (int i = 0; i < n-1; i++)
                {
                    names.Enqueue(names.Dequeue());
                }

                if (PrimeTool.IsPrime(cycle))
                {
                    Console.WriteLine($"Prime {names.Peek()}");
                }
                else
                {
                    Console.WriteLine($"Removed {names.Dequeue()}");
                }
                cycle++;
            }

            Console.WriteLine($"Last is {names.Dequeue()}");
        }
    }

    public static class PrimeTool
    {
        public static bool IsPrime(int candidate)
        {
            // Test whether the parameter is a prime number.
            if ((candidate & 1) == 0)
            {
                if (candidate == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // Note:
            // ... This version was changed to test the square.
            // ... Original version tested against the square root.
            // ... Also we exclude 1 at the end.
            for (int i = 3; (i * i) <= candidate; i += 2)
            {
                if ((candidate % i) == 0)
                {
                    return false;
                }
            }
            return candidate != 1;
        }
    }
}
