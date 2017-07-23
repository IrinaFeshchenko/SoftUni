namespace Patterns.Commands
{
    using System.Collections.Generic;

    class CommandParser
    {
        private Dictionary<string, Command> commands;

        public CommandParser()
        {
           this.Initialize();
        }

        public Command Parse(string commandAsString, MyData data)
        {
            if (commands.ContainsKey(commandAsString))
            {
                return commands[commandAsString].Create(data);
            }
            else
            {
                return new NotFoundCommand(data);
            }
        }

        private void Initialize()
        {
            commands = new Dictionary<string, Command>();
            commands.Add("bye",new PrintByeCommand(null));
            commands.Add("greet", new PrintGreetingCommand(null));
            commands.Add("exit", new ExitCommand(null));
            commands.Add("increase", new IncreaseNumberCommand(null));
            commands.Add("print", new PrintStringCommand(null));
            commands.Add("report", new PrintNumberCommand(null));
        }
    }
}
