using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DependencyInversion
{
    public class StartUp
    {
        public static void Main()
        {
            PrimitiveCalculator calculator = new PrimitiveCalculator();

            string[] input;
            while ((input = Console.ReadLine().Split())[0] != "End")
            {

                if (input[0] == "mode")
                {
                    calculator.ChangeStrategy(input[1][0]);
                }
                else
                {
                    int result = calculator.PerformCalculation(int.Parse(input[0]), int.Parse(input[1]));
                    Console.WriteLine(result);
                }
            }
        }
    }
}
