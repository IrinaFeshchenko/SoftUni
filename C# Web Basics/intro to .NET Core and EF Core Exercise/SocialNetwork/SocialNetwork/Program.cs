namespace SocialNetwork
{
    using Microsoft.EntityFrameworkCore;
    using SocialNetwork.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static Random random = new Random();

        public static void Main()
        {
            using (var db = new SocialNetworkDbContext())
            {
                //db.Database.Migrate();

                //SeedUsers(db);

                PrintUsersWithFriends(db);
            }
        }

        private static void PrintUsersWithFriends(SocialNetworkDbContext db)
        {
            var result = db
                .Users
                .Select(u => new
                {
                    Name = u.Username,
                    TotalFriends = u.FromFriends.Count + u.ToFriends.Count,
                    Status = u.IsDeleted ? "Inactive" : "Active",
                })
                .OrderByDescending(u => u.TotalFriends)
                .ThenBy(u => u.Name)
                .ToList();

            foreach (var user in result)
            {
                Console.WriteLine($"{user.Name} - {user.TotalFriends} friends - {user.Status}");
            }
        }

        private static void SeedUsers(SocialNetworkDbContext db)
        {
            const int totalUsers = 50;
            var biggestUserId = db.Users
                .Select(u => u.Id)
                .OrderByDescending(u => u)
                .FirstOrDefault();

            var allUsers = new List<User>();

            for (int i = biggestUserId; i < totalUsers+biggestUserId; i++)
            {
                var user = new User()
                {
                    Username = $"Username {i}",
                    Password = $"Passw0rd#$",
                    Email = $"email@email{i}.com",
                    RegisteredOn = DateTime.Now.AddDays(100 + i * 10),
                    LastTimeLoggedIn = DateTime.Now.AddDays(i),
                    Age = i + 1
                };
                
                allUsers.Add(user);
                db.Users.Add(user);
            }

            db.SaveChanges();

            var userIds = allUsers.Select(u => u.Id).ToList();

            for (int i = 0; i < userIds.Count; i++)
            {
                var currentUserId = userIds[i];

                var totalFriends = random.Next(5, 11);

                for (int j = 0; j <totalFriends; j++)
                {
                    var friendId = userIds[random.Next(0, userIds.Count)];

                    var validFriendship = true;

                    if (friendId == currentUserId)
                    {
                        validFriendship = false;
                    }

                    var friendshipExist = db
                        .Friendships
                        .Any(f =>
                        (f.FromUserId == currentUserId && f.ToUserId == friendId) ||
                        (f.ToUserId == currentUserId && f.FromUserId == friendId));

                    if (friendshipExist)
                    {
                        validFriendship = false;
                    }

                    if (!validFriendship)
                    {
                        j--;
                        continue;
                    }

                    db.Friendships.Add(new Friendship
                    {
                        FromUserId = currentUserId,
                        ToUserId = friendId
                    });

                    db.SaveChanges();
                }
            }
        }
    }
}
