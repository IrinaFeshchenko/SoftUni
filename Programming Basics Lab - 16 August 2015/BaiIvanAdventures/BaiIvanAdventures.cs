

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BaiIvanAdventures
    {
        static void Main()
        {
            Dictionary<int, decimal> day = new Dictionary<int, decimal>()
            {
                {0,25.0m },{1,21.0m },{2,14.0m },{3,17.0m},{4,45.0m },{5,59.0m},{6,42.0m}
            };

            int dayOfWeek = int.Parse(Console.ReadLine());
            decimal money = decimal.Parse(Console.ReadLine());
            decimal wantsToDrink = decimal.Parse(Console.ReadLine());
            List<string> result = new List<string>();

            decimal canAfford = money / day[dayOfWeek];
            string baiIvanCondition;

            if (canAfford<1.0m)
            {
                baiIvanCondition = "sober";
            }
            else if (canAfford <=1.5m)
            {
                baiIvanCondition = "drunk";
            }
            else
            {
                baiIvanCondition = "very drunk";
            }

            if (canAfford < wantsToDrink)
            {
                Console.WriteLine("Bai Ivan is {0} and quite sad. He wanted to drink another {1:f2} l. of alcohol",baiIvanCondition,wantsToDrink-canAfford);
            }
            else if (canAfford == wantsToDrink)
            {
                Console.WriteLine("Bai Ivan is {0} and happy. He is as drunk as he wanted", baiIvanCondition);
            }
            else
            {
                Console.WriteLine("Bai Ivan is {0} and very happy and he shared {1:f2} l. of alcohol with his friends", baiIvanCondition, canAfford-wantsToDrink);
            }
        }
    }
}
