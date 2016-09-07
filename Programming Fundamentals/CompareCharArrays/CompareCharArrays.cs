

namespace Namespace
{
    using System;
    class CompareCharArrays
    {
        static void Main()
        {
            string s1 = Console.ReadLine().Replace(" ","");
            string s2 = Console.ReadLine().Replace(" ", "");

            string first = s1;
            string second = s2;
            int len = Math.Min(s1.Length,s2.Length);

            for (int i = 0; i < len; i++)
            {


                if (s1[i]< s2[i] )
                {
                    first = s1;
                    second = s2;
                }
                else if (s1[i] > s2[i])
                {
                    first = s2;
                    second = s1;
                }
                else if (i == len -1)
                {
                    if (s1.Length< s2.Length)
                    {
                        first = s1;
                        second = s2;
                    }
                    else
                    {
                        first = s2;
                        second = s1;
                    }
                }
            }

            Console.WriteLine(first);
            Console.WriteLine(second);
        }
    }
}
