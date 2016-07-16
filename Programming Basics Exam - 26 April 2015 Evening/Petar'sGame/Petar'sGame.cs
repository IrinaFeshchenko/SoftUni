

namespace Namespace
{
    using System;
    using System.Numerics;

    class PetarsGame
    {
        static void Main()
        {
            ulong start = ulong.Parse(Console.ReadLine());
            ulong end = ulong.Parse(Console.ReadLine());
            string s = Console.ReadLine();

            decimal sum = 0;
            for (ulong i = start; i < end; i++)
            {
                if (i % 5 == 0)
                {
                    sum += i;
                }
                else
                {
                    sum += i % 5;
                }
            }

            string num;
            string result = sum.ToString();

            if (sum % 2 == 0)
            {
                num = result[0].ToString();
                
            }
            else
            {
                num = result[result.Length - 1].ToString();
            }
            result = result.Replace(num, s);
            Console.WriteLine(result);
        }
    }
}
