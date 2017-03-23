namespace PhotoShare.Client.Core
{
    using Commands;
    using Services;
    using System;
    using System.Linq;

    public class CommandDispatcher
    {
        public string DispatchCommand(string[] commandParameters)
        {
            string result = string.Empty;
            string command = commandParameters[0];
            commandParameters = commandParameters.Skip(1).ToArray();

            if (command.ToLower() == "RegisterUser".ToLower())
            {
                UserService userService = new UserService();
                RegisterUserCommand registerUser = new RegisterUserCommand(userService);
                result = registerUser.Execute(commandParameters);
            }
            else if (command.ToLower() == "AddTown".ToLower())
            {
                TownService townService = new TownService();
                AddTownCommand addTown = new AddTownCommand(townService);
                result = addTown.Execute(commandParameters);
            }
            return result;
        }
    }
}
