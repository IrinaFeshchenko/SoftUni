namespace _04MasterHerbalist
{
    using System;

    public class MasterHerbalist
    {
        public static void Main()
        {
            int dailyExpenses = int.Parse(Console.ReadLine());
            string line = Console.ReadLine();
            int totalMoney = 0;
            int days = 0;
            while (line != "Season Over")
            {
                days++;
                string[] parameters = line.Split();
                int hours = int.Parse(parameters[0]);
                string path = parameters[1];
                int price = int.Parse(parameters[2]);
                int herbs = 0;
                for (int i = 0; i < hours; i++)
                {
                    if (path[i % path.Length] == 'H')
                    {
                        herbs++;
                    }
                }
                totalMoney += herbs * price;
                line = Console.ReadLine();
            }
            decimal averageEarnings = (decimal)totalMoney / days;
            if (averageEarnings >= dailyExpenses)
            {
                Console.WriteLine("Times are good. Extra money per day: {0:F2}.", averageEarnings - dailyExpenses);
            }
            else
            {
                int totalExpenses = dailyExpenses * days;
                Console.WriteLine("We are in the red. Money needed: {0}.", totalExpenses - totalMoney);
            }
        }
    }
}
