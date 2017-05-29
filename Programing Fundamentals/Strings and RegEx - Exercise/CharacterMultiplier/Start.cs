namespace CharacterMultiplier
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Start
    {
        public static void Main()
        {
            string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            char[] s1 = args[0].ToCharArray();
            char[] s2 = args[1].ToCharArray();

            long result = 0;
            for (int i = 0; i < Math.Max(s1.Length, s2.Length); i++)
            {
                int first = i < s1.Length ? s1[i] : 1;
                int second = i < s2.Length ? s2[i] : 1;
                result += first * second;
            }

            Console.WriteLine(result);
        }
    }
}
