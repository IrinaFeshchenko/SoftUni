namespace Mordor_s_Cruelty_Plan.Factories
{
    using Mordor_s_Cruelty_Plan.Models;
    using Mordor_s_Cruelty_Plan.Models.Foods;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FoodFactory
    {
        public Food GetFood(string foodType)
        {
            switch (foodType.ToLower())
            {
                case "cram":
                    return new Cram();
                case "lembas":
                    return new Lembas();
                case "melon":
                    return new Melon();
                case "apple":
                    return new Apple();
                case "Mushrooms":
                    return new Mushrooms();
                case "honeycake":
                    return new HoneyCake();
                default:
                    return new Junk();

            }
        }
    }
}
