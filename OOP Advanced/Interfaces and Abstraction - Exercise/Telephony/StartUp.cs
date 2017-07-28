namespace Telephony
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string[] numbers = Console.ReadLine().Split();//(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string[] sites = Console.ReadLine().Split();//(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                                           

            var phone = new Smartphone();

            foreach (var number in numbers)
            {
                Console.WriteLine(phone.Call(number));
            }

            foreach (var site in sites)
            {
                Console.WriteLine(phone.Browse(site));
            }
        }
    }
}
