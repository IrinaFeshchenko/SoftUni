
namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Linq;
    using Utilities;
    using Data;
    using Models;

    public class LoginCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(2, inputArgs);

            string username = inputArgs[0];
            string password = inputArgs[0];

            if (AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LogoutFirst);
            }

            User user = this.GetUserByCredentials(username, password);

            if (user == null)
            {
                throw new ArgumentException(Constants.ErrorMessages.UserOrPasswordIsInvalid);
            }

            AuthenticationManager.Login(user);

            return $"User {username} successfully logged in!";
        }

        private User GetUserByCredentials(string username, string password)
        {
            User user = new User();

            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password && !u.IsDeleted);
            }

            return user;
        }
    }
}
