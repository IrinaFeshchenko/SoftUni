namespace _03.Formatting_Numbers
{
    using System;

    public class Startup
    {
        static void Main()
        {
            string[] tokens = Console.ReadLine().Split(new[] { ' ','\t' }, StringSplitOptions.RemoveEmptyEntries);

            long num1 = long.Parse(tokens[0]);
            string numS = Convert.ToString(int.Parse(tokens[0]),2).PadLeft(10,'0').Substring(0, 10);
            double num2 = double.Parse(tokens[1]);
            double num3 = double.Parse(tokens[2]);

            Console.WriteLine($"|{num1,-10:X}|{numS}|{num2,10:F2}|{num3,-10:F3}|");
        }
    }
}
