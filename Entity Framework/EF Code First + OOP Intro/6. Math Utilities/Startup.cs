namespace _6.Math_Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main()
        {
            Console.WriteLine("enter math operations on new lines:");

            List<double> result = new List<double>();
            while (true)
            {
                string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (args[0].ToLower()=="end") break;

                string command = args[0];
                double num1 = double.Parse(args[1]);
                double num2 = double.Parse(args[2]);

                if (command.ToLower() == "sum")
                {
                    result.Add( MathUtil.Sum(num1, num2));
                }
                else if (command.ToLower() == "subtract")
                {
                    result.Add(MathUtil.Substract(num1, num2));
                }
                else if (command.ToLower() == "multiply")
                {
                    result.Add(MathUtil.Multiply(num1, num2));
                }
                else if (command.ToLower() == "divide")
                {
                    result.Add(MathUtil.Divide(num1, num2));
                }
                else if (command.ToLower() == "percentage")
                {
                    result.Add(MathUtil.Percentage(num1, num2));
                }
            }

            foreach (var r in result)
            {
                Console.WriteLine($"{r:f2}");
            }
        }
    }
}
