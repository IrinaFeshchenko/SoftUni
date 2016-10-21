namespace LettersChangeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    public class Start
    {
        public static void Main()
        {
            string[] args = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            double Sum = 0;
            foreach (var w in args)
            {
                double res = 0;
                if (char.IsUpper(w[0]))
                {
                    double pos = w[0] - 'A' + 1;
                    double num = double.Parse(w.Substring(1, w.Length - 2));
                    res = num / pos;
                }
                else if (char.IsLower(w[0]))
                {
                    double pos = w[0] - 'a' + 1;
                    double num = double.Parse(w.Substring(1, w.Length - 2));
                    res = num * pos;
                }
                if (char.IsUpper(w[w.Length - 1]))
                {
                    double pos = w[w.Length - 1] - 'A' + 1;
                    res = res - pos;
                }
                else if (char.IsLower(w[w.Length - 1]))
                {
                    double pos = w[w.Length - 1] - 'a' + 1;
                    res = res + pos;
                }
                Sum += (double)res;

            }

            Console.WriteLine($"{Sum:f2}");
        }
    }
}
