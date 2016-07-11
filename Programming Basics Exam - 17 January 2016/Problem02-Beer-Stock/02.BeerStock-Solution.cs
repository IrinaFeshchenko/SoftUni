namespace _02BeerStock
{
    using System;

    public class BeerStock
    {
        public static void Main()
        {
            int reservedBeers = int.Parse(Console.ReadLine());
            string line = Console.ReadLine();
            long beersCount = 0;
            while (line != "Exam Over")
            {
                string[] parameters = line.Split();
                long amount = long.Parse(parameters[0]);
                string type = parameters[1];

                switch (type)
                {
                    case "cases":
                        beersCount += amount * 24;
                        break;
                    case "sixpacks":
                        beersCount += amount * 6;
                        break;
                    default:
                        beersCount += amount;
                        break;
                }

                line = Console.ReadLine();
            }

            beersCount = beersCount - (beersCount / 100);
            if (beersCount >= reservedBeers)
            {
                long beersLeft = beersCount - reservedBeers;
                long cases = beersLeft / 24;
                beersLeft = beersLeft % 24;
                long sixpacks = beersLeft / 6;
                beersLeft = beersLeft % 6;
                Console.WriteLine(
                    "Cheers! Beer left: {0} cases, {1} sixpacks and {2} beers.",
                    cases,
                    sixpacks,
                    beersLeft);
            }
            else
            {
                long beersNeeded = reservedBeers - beersCount;
                long cases = beersNeeded / 24;
                beersNeeded = beersNeeded % 24;
                long sixpacks = beersNeeded / 6;
                beersNeeded = beersNeeded % 6;
                Console.WriteLine(
                    "Not enough beer. Beer needed: {0} cases, {1} sixpacks and {2} beers.",
                    cases,
                    sixpacks,
                    beersNeeded);
            }
        }
    }
}
