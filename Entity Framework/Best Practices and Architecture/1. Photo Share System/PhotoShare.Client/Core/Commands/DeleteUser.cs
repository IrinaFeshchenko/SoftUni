namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using Services;
    using System;
    using System.Linq;

    public class DeleteUser : Command
    {
        private UserService userService;

        public DeleteUser(UserService userService)
        {
            this.userService = userService;
        }
        // DeleteUser <username>
        public override string Execute(string[] data)
        {
            string username = data[0];

            if (!this.userService.IsUserExisting(username))
            {
                throw new InvalidOperationException($"User with {username} was not found!");
            }

            if (this.userService.IsUserDeleted(username))
            {
                throw new InvalidOperationException($"User {username} is already deleted!");
            }

            User user = this.userService.GetUserByUsername(username);
            userService.DeleteUser(user);
            return $"User {username} was deleted from the database!";
        }
    }
}
