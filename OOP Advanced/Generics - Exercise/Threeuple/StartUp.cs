using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Threeuple
{
    public class Startup
    {
        public static void Main()
        {
            var args = Console.ReadLine().Split();
            var names = $"{args[0]} {args[1]}";
            var address = args[2];
            var town = args[3];
            var namesAddress = new Threeuple<string, string, string>(names, address,town);

            args = Console.ReadLine().Split(' ');
            var name = args[0];
            int liters = int.Parse(args[1]);
            bool isDrunk;

            if (args[2] == "drunk")
            {
                isDrunk=true;
            }
            else
            {
                isDrunk = false;
            }
            var nameLiters = new Threeuple<string, int, bool>(name, liters, isDrunk);

            args = Console.ReadLine().Split(' ');
            string userName = args[0];
            double balance = double.Parse(args[1]);
            string bank = args[2];
            var money = new Threeuple<string, double, string>(userName, balance, bank );

            Console.WriteLine(namesAddress.ToString());
            Console.WriteLine(nameLiters.ToString());
            Console.WriteLine(money.ToString());
        }
    }
}
