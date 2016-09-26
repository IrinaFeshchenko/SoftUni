

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ArrayMatcher
    {
        static void Main()
        {
            string input = Console.ReadLine();
            List<char> result = new List<char>();
            char[] arr1 = input.Split('\\')[0].ToArray();
            char[] arr2 = input.Split('\\')[1].ToArray();
            string command = input.Split('\\')[2];

            if (command == "join")
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    for (int j = 0; j < arr2.Length; j++)
                    {
                        if (arr1[i] == arr2[j])
                        {
                            result.Add(arr1[i]);
                        }
                    }
                }
            }
            else if (command == "right exclude")
            {
                Exclude(arr1, arr2, result);
            }
            else if (command == "left exclude")
            {
                Exclude(arr2,arr1,result);
            }

            result.Sort();
            Console.WriteLine(string.Join("", result));
        }

        private static void Exclude(char[] arr1, char[] arr2, List<char> result)
        {
            for (int i = 0; i < arr1.Length; i++)
            {
                bool noMatch = true;
                for (int j = 0; j < arr2.Length; j++)
                {
                    if (arr1[i] == arr2[j])
                    {
                        noMatch = false;
                    }
                }
                if (noMatch)
                {
                    result.Add(arr1[i]);
                }
            }
        }
    }
}
