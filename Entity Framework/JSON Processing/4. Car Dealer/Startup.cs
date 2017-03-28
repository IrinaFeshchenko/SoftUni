
namespace _4.Car_Dealer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main()
        {
            var context = new CarsDBContext();
            context.Database.Initialize(true);
        }
    }
}
