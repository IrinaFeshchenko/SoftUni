namespace _12.Remove_Inactive_Users
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main()
        {
            var context = new UsersContext();

            Console.WriteLine("Enter date (01 May 2013): ");
            string s = Console.ReadLine();
            DateTime input = DateTime.ParseExact(s, "dd MMM yyyy",CultureInfo.InvariantCulture);

            var users = context.Users
                .Where(u => u.LastTimeLoggedIn < input)
                .ToList();

            int count = 0;

            foreach (var u in users)
            {
                u.IsDeleted = true;
                count++;
            }

            if (count == 0)
            {
                Console.WriteLine($"No users have been deleted");
            }
            else if (count == 1)
            {
                Console.WriteLine($"1 user have been deleted");
            }
            else if (count>1)
            {
                Console.WriteLine($"{count} users have been deleted");
            }

            context.SaveChanges();
        }
    }
}
