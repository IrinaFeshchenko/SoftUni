namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class ModifyUserCommand : Command
    {
        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public override string Execute(string[] data)
        {
            throw new NotImplementedException();
        }
    }
}
