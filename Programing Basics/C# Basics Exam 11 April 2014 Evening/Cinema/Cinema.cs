

namespace Namespace
{
    using System;

    class Cinema
    {
        static void Main()
        {
            string type = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int colunns = int.Parse(Console.ReadLine());

            decimal premiereTicketPrice = 12m;
            decimal normalTicketPrice = 7.5m;
            decimal discountTicketPrice = 5m;
            int seats = rows * colunns;
            decimal income = 0;

            if (type == "Premiere")
            {
                income = seats * premiereTicketPrice;
            }
            else if (type == "Normal")
            {
                income = seats * normalTicketPrice;
            }
            else if (type == "Discount")
            {
                income = seats * discountTicketPrice;
            }

            Console.WriteLine("{0:f2} leva",income);
        }
    }
}
