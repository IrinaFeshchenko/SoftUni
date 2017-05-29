namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using Services;
    using System;
    using System.Linq;

    public class ModifyUserCommand : Command
    {

        private UserService userService;
        private TownService townService;

        public ModifyUserCommand(UserService userService, TownService townService)
        {
            this.userService = userService;
            this.townService = townService;

        }
        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public override string Execute(string[] data)
        {
            string username = data[0];
            string propType = data[1].ToLower();
            string value = data[2];

            if (!this.userService.IsUserExisting(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }

            User user = this.userService.GetUserByUsername(username);

            if (propType.Equals("Password", StringComparison.OrdinalIgnoreCase))
            {
                if (!(value.Any(c => char.IsLower(c)) && value.Any(c => char.IsDigit(c))))
                {
                    throw new ArgumentException($"Value {value} not valid! \nInvalid password");
                }

                userService.UpdatePassword(user);
            }
            else if (propType.Equals("BornTown", StringComparison.OrdinalIgnoreCase))
            {
                if (!this.townService.IsTownExisting(value))
                {
                    throw new ArgumentException($"Value {value} not valid!\nTown {value} not found!");
                }

                user.BornTown = this.townService.GetTownBytownName(value);
                userService.UpdateBornTown(user);
            }
            else if (propType.Equals("CurrentTown", StringComparison.OrdinalIgnoreCase))
            {
                if (!this.townService.IsTownExisting(value))
                {
                    throw new ArgumentException($"Value {value} not valid!\nTown {value} not found!");
                }

                user.CurrentTown = this.townService.GetTownBytownName(value);
                userService.UpdateCurrentTown(user);
            }
            else
            {
                throw new ArgumentException($"Property {propType} not supported!");
            }

            return $"User {username} {propType} is {value}.";
        }
    }
}
