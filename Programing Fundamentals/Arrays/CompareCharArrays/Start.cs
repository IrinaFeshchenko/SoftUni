

namespace CompareCharArrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Start
    {
        static void Main()
        {
            char[] arr1 = Console.ReadLine().Split().Select(char.Parse).ToArray();
            char[] arr2 = Console.ReadLine().Split().Select(char.Parse).ToArray();
            bool firstIsFirst = true;
            bool lettersAreEqual = true;

            for (int i = 0; i < Math.Min(arr1.Length,arr2.Length); i++)
            {
                if (arr1[i] < arr2[i])
                {
                    firstIsFirst = true;
                    lettersAreEqual = false;
                    break;
                }
                else if (arr1[i] > arr2[i])
                {
                    firstIsFirst = false;
                    lettersAreEqual = false;
                    break;
                }
            }

            if (lettersAreEqual)
            {
                if (arr1.Length > arr2.Length)
                {
                    firstIsFirst = false;
                }
                else
                {
                    firstIsFirst = true;
                }
            }


            if (firstIsFirst)
            {
                Console.WriteLine(string.Join("", arr1));
                Console.WriteLine(string.Join("", arr2));
            }
            else
            {
                Console.WriteLine(string.Join("", arr2));
                Console.WriteLine(string.Join("", arr1));
            }
        }
    }
}
