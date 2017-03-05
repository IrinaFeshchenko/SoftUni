namespace _11.Get_Users_by_Email_Provider
{
    using System;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            Console.Write("Enter email provider(d.edu, t.org): ");
            string input = Console.ReadLine();

            UsersContext context = new UsersContext();

            var users = context.Users
                .Where(u => u.Email.EndsWith(input))
                .Select(u=> new { u.Username, u.Email});

            foreach (var u in users)
            {
                Console.WriteLine($"{u.Username} {u.Email}");
            }
        }
    }
}
