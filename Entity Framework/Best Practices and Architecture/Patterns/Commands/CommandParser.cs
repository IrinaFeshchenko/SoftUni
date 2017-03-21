namespace Patterns.Commands
{
    using System.Collections.Generic;

    class CommandParser
    {
        private Dictionary<string, Command> commands;

        public CommandParser()
        {
            this.Initialize(null);
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

        private void Initialize(MyData data)
        {
            commands = new Dictionary<string, Command>();
            commands.Add("bye",new PrintByeCommand(data));
            commands.Add("greet", new PrintGreetingCommand(data));
            commands.Add("exit", new ExitCommand(data));
            commands.Add("increase", new IncreaseNumberCommand(data));
            commands.Add("print", new PrintStringCommand(data));
        }
    }
}
