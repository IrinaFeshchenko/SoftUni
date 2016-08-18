

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ArrayModifier
    {
        static List<long> array = new List<long>();
        static void Main()
        {
            array = Console.ReadLine().Split(' ')
                .Select(x => long.Parse(x))
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] parts = command.Split();

                if (command[0] == 's')
                {
                    swap(int.Parse(parts[1]), int.Parse(parts[2]));
                }

                if (command[0] == 'm')
                {
                    multiply(int.Parse(parts[1]), int.Parse(parts[2]));
                }

                if (command[0] == 'd')
                {
                    decrease();
                }
            }

            Console.WriteLine(string.Join(", ", array));
        }

        private static void swap(int index1, int index2)
        {
            long temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        private static void multiply(int index1, int index2)
        {
            array[index1] = array[index1] * array[index2];
        }

        private static void decrease()
        {
            int length = array.Count();
            for (int i = 0; i < length; i++)
            {
                array[i] = array[i] - 1;
            }
        }
    }
}
