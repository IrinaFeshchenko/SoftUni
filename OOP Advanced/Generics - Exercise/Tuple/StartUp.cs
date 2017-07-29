using System;

namespace Tuple
{
    public class Startup
    {
        public static void Main()
        {
            var args = Console.ReadLine().Split();
            var names = $"{args[0]} {args[1]}";
            var address = args[2];
            var namesAddress = new Tuple<string,string>(names, address);

            args = Console.ReadLine().Split(' ');
            var name = args[0];
            var liters = int.Parse(args[1]);
            var nameLiters = new Tuple<string, int>(name, liters);

            args = Console.ReadLine().Split(' ');
            int number1 = int.Parse(args[0]);
            double number2 = double.Parse(args[1]);
            var numbers = new Tuple<int, double>(number1, number2);

            Console.WriteLine(namesAddress.ToString());
            Console.WriteLine(nameLiters.ToString());
            Console.WriteLine(numbers.ToString());
        }
    }
}
