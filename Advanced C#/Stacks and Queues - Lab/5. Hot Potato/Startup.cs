
namespace _5.Hot_Potato
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
            List<string> exitOrder = new List<string>();

            int count = 1;
            while (names.Count>1)
            {
                if (count % n==0)
                {
                    exitOrder.Add(names.Dequeue());
                }
                else
                {
                    names.Enqueue(names.Dequeue());
                }
                count++;
            }

            foreach (var name in exitOrder)
            {
                Console.WriteLine($"Removed {name}");
            }

            Console.WriteLine($"Last is {names.Dequeue()}");
        }
    }
}
