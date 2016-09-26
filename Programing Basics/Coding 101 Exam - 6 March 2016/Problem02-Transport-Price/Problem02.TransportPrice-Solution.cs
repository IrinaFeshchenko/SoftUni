using System;

class TransportPrice
{
    static void Main()
    {
        var distance = int.Parse(Console.ReadLine());
        var dayOrNight = Console.ReadLine();

        var taxiRate = 0.90;
        if (dayOrNight == "day") taxiRate = 0.79;

        if (distance < 20)
            Console.WriteLine("Taxi: {0}", 0.70 + distance * taxiRate);
        else if (distance < 100)
            Console.WriteLine("Bus: {0}", distance * 0.09);
        else
            Console.WriteLine("Train: {0}", distance * 0.06);
    }
}
