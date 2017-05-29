namespace _8.Create_User
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
            User gosho = new User()
            {
                Username = "Gosho",
                Password = "Aa3$aa_aaa",
                Email = "gosho@yahoo.com",
                RegisteredOn = DateTime.Now,
                LastTimeLoggedIn = DateTime.Now,
                Age = 30,
                IsDeleted = false,
            };

            var context = new UserContext();
            context.users.Add(gosho);
            context.SaveChanges();
        }
    }
}
