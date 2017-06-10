namespace _05.Concatenate_Strings
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Startup
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                sb.Append(Console.ReadLine()).Append(" ");
            }

            Console.WriteLine(sb);
        }
    }
}
