

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Operations
    {
        static void Main()
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            double result;
            if (command == "+")
            {
                result = n1 + n2;
                Console.WriteLine("{0} + {1} = {2} - {3}",n1,n2,result,result%2==0?"even":"odd");
            }
            else if (command == "-")
            {
                result = n1 - n2;
                Console.WriteLine("{0} - {1} = {2} - {3}", n1, n2, result, result % 2 == 0 ? "even" : "odd");
            }
            else if (command == "*")
            {
                result = n1 * n2;
                Console.WriteLine("{0} * {1} = {2} - {3}", n1, n2, result, result % 2 == 0 ? "even" : "odd");
            }
            else if (command == "/")
            {      
                if (n2 == 0)
                {
                    Console.WriteLine("Cannot divide {0} by zero", n1);
                }
                else
                {
                    result = (double)n1 / n2;
                    Console.WriteLine("{0} / {1} = {2:f2}", n1, n2, result);
                }             
            }
            else if (command == "%")
            {
                if (n2==0)
                {
                    Console.WriteLine("Cannot divide {0} by zero",n1);
                }
                else
                {
                    result = n1 % n2;
                    Console.WriteLine("{0} % {1} = {2}", n1, n2, result);
                }
            }
        }
    }
}
