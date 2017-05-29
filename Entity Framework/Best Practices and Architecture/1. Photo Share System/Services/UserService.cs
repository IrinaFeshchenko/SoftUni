
namespace Services
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class UserService
    {
        public void RegisterUser(string username, string password, string email)
        {
            User user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                IsDeleted = false,
                RegisteredOn = DateTime.Now,
                LastTimeLoggedIn = DateTime.Now
            };

            using (PhotoShareContext context = new PhotoShareContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public bool IsUserExisting(string username)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Users.Any(u => u.Username == username);
            }
        }

        public bool IsUserDeleted(string username)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Users.FirstOrDefault(u => u.Username == username).IsDeleted??false;
            }
        }

        public User GetUserByUsername(string username)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Users.SingleOrDefault(u => u.Username == username);
            }
        }

        public void UpdatePassword(User updatedUser)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                context.Users.SingleOrDefault(u=>u.Id == updatedUser.Id).Password = updatedUser.Password;
                context.SaveChanges();
            }
        }

        public void UpdateBornTown(User updatedUser)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                context.Users.SingleOrDefault(u => u.Id == updatedUser.Id).BornTown = 
                    context.Towns.FirstOrDefault(t => t.Id == updatedUser.BornTown.Id);
                context.SaveChanges();
            }
        }

        public void UpdateCurrentTown(User updatedUser)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                context.Users.SingleOrDefault(u => u.Id == updatedUser.Id).CurrentTown = 
                    context.Towns.FirstOrDefault(t => t.Id == updatedUser.CurrentTown.Id);
                context.SaveChanges();
            }
        }

        public void DeleteUser(User userToDelete)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                context.Users.SingleOrDefault(u => u.Id == userToDelete.Id).IsDeleted = true;
                context.SaveChanges();
            }
        }
    }
}