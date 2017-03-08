namespace _6.Customers_Migration.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_6.Customers_Migration.SalesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(_6.Customers_Migration.SalesContext context)
        {
            Customer jim = new Customer("Jim","Jonson", "Jim@yahoo.com", "2h32kh32kh32k");
            Customer jon = new Customer("Jon","Dowson", "jon@gmail.com", "45l6j4l5j6l4");
            Customer pit = new Customer("Pit","Bartlet", "pit@hotmail.com", "jl45l6jl4k5l6j");
            Customer nick = new Customer("Nick", "Jonson", "nick@gmail.com", "36oiu456ouo456");
            Customer bill = new Customer("Bill","Gates", "bill@yahoo.com", "1cty2y34y2f4y234");

            context.Customers.Add(jim);
            context.Customers.Add(jon);
            context.Customers.Add(pit);
            context.Customers.Add(nick);
            context.Customers.Add(bill);
        }
    }
}
