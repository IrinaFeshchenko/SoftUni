namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class ExitCommand : Command
    {
        public override string Execute(string[] data)
        {
            Environment.Exit(0);
            return "Bye-bye!";
        }
    }
}
