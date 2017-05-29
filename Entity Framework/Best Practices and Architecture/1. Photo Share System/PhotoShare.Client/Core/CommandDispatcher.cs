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
            TownService townService = new TownService();
            UserService userService = new UserService();
            string result = string.Empty;
            string command = commandParameters[0];
            commandParameters = commandParameters.Skip(1).ToArray();

            if (command.Equals("RegisterUser", StringComparison.OrdinalIgnoreCase))
            {

                RegisterUserCommand registerUser = new RegisterUserCommand(userService);
                result = registerUser.Execute(commandParameters);
            }
            else if (command.Equals("AddTown", StringComparison.OrdinalIgnoreCase))
            {

                AddTownCommand addTown = new AddTownCommand(townService);
                result = addTown.Execute(commandParameters);
            }
            else if (command.Equals("ModifyUser", StringComparison.OrdinalIgnoreCase))
            {
                ModifyUserCommand modifyUser = new ModifyUserCommand(userService, townService);
                result = modifyUser.Execute(commandParameters);
            }
            else if (command.Equals("Exit", StringComparison.OrdinalIgnoreCase))
            {
                ExitCommand exitCommand = new ExitCommand();
                exitCommand.Execute(commandParameters);
            }
            else if (command.Equals("DeleteUser", StringComparison.OrdinalIgnoreCase))
            {
                DeleteUser DeleteUserCommand = new DeleteUser(userService);
                result = DeleteUserCommand.Execute(commandParameters);
            }
            else
            {
                result = "Command not found!";
            }
            return result;
        }
    }
}
