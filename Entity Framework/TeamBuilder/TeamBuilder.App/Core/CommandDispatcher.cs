
namespace TeamBuilder.App.Core
{
    using Commands;
    using System;
    using System.Linq;

    public class CommandDispatcher
    {
        public string Dispatch(string input)
        {
            string result = string.Empty;

            string[] inputArgs = input.Split(new[] { ' ','\t' }, StringSplitOptions.RemoveEmptyEntries);

            string commandName = input.Length > 0 ? inputArgs[0] : string.Empty;
            inputArgs = inputArgs.Skip(1).ToArray();

            switch (commandName.ToLower())
            {
                case "registeruser":
                    RegisterUserCommand registerUser = new RegisterUserCommand();
                    result = registerUser.Execute(inputArgs);
                    break;
                case "exit":
                    ExitCommand exit = new ExitCommand();
                    exit.Execute(inputArgs); ;
                    break;
                case "Login":
                    LoginCommand login = new LoginCommand();
                    login.Execute(inputArgs); ;
                    break;
                case "Logout":
                    LogoutCommand logout = new LogoutCommand();
                    logout.Execute(inputArgs); ;
                    break;
                default:
                    throw new NotSupportedException($"Command {commandName} not supported!");
            }

            return result;
        }
    }
}
