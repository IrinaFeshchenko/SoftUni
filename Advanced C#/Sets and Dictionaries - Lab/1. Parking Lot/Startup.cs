// Write program that:
// •	Record car number for every car that enter in parking lot
// •	Remove car number when the car go out
// •	Input will be string in format[direction, carNumber]
// •	input end with string "END"
// Print the output with all car numbers which are in parking lot


namespace _1.Parking_Lot
{
    using System;
    using System.Collections.Generic;

    class Startup
    {
        static void Main()
        {
            string input = string.Empty;
            SortedSet<string> cars = new SortedSet<string>();

            while ((input = Console.ReadLine())!="END")
            {
                string[] args = input.Split(',');
                string direction = args[0].Trim();
                string carNumber = args[1].Trim();

                if (direction == "IN")
                {
                    cars.Add(carNumber);
                }
                else if (direction == "OUT")
                {
                    cars.Remove(carNumber);
                }
            }

            if (cars.Count==0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                Console.WriteLine(string.Join("\n",cars));
            }
        }
    }
}
