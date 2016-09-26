namespace _01CakeTycoon
{
    using System;

    public class CakeTycoon
    {
        public static void Main()
        {
            ulong cakesWanted = ulong.Parse(Console.ReadLine());
            double kilosPerCake = double.Parse(Console.ReadLine());
            uint flourKilos = uint.Parse(Console.ReadLine());
            uint truffles = uint.Parse(Console.ReadLine());
            uint trufflePrice = uint.Parse(Console.ReadLine());

            ulong truffleCost = (ulong)truffles * trufflePrice;
            double cakesProduced = Math.Floor(flourKilos / kilosPerCake);

            if (cakesProduced < cakesWanted)
            {
                double kilogramsNeeded = (kilosPerCake * cakesWanted) - flourKilos;
                Console.WriteLine("Can make only {0} cakes, need {1:F2} kg more flour", cakesProduced, kilogramsNeeded);
            }
            else
            {
                double cakeCost = ((double)truffleCost / cakesWanted) * 1.25d;
                Console.WriteLine("All products available, price of a cake: {0:F2}", cakeCost);
            }
        }
    }
}
