

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class GreaterOfTwoValues
    {
        static void Main()
        {
            string type = Console.ReadLine();

            if (type== "int")
            {
                int first = int.Parse(Console.ReadLine());
                int second = int.Parse(Console.ReadLine());
                int max = GetMax(first,second);
                Console.WriteLine(max);
            }
            else if (type == "char")
            {
                char first = char.Parse(Console.ReadLine());
                char second = char.Parse(Console.ReadLine());
                char max = GetMax(first, second);
                Console.WriteLine(max);
            }
            else if (type == "string")
            {
                string first = Console.ReadLine();
                string second = Console.ReadLine();
                string max = GetMax(first, second);
                Console.WriteLine(max);
            }
        }

        private static string GetMax(string first, string second)
        {
            return first.CompareTo(second)>0 ? first : second;
        }

        private static char GetMax(char first, char second)
        {
            return (char)Math.Max(first,second);
        }

        private static int GetMax(int first, int second)
        {
            return Math.Max(first,second);
        }
    }
}
