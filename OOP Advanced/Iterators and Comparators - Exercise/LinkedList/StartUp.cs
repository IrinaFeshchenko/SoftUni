using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace LinkedList_
{
    public class StartUp
    {
        public static void Main()
        {
            var list = new LinkedList();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine().Split(' ');
                string command = args[0];
                int value = int.Parse(args[1]);

                if (command == "Add")
                {
                    list.Add(value);
                }
                else
                {
                    list.Remove(value);
                }
            }

            Console.WriteLine(list.Count);
            foreach (var value in list)
            {
                Console.Write(value + " ");
            }
        }
    }
}
