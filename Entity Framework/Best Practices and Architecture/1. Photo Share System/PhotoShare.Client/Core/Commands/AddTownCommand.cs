
namespace PhotoShare.Client.Core.Commands
{
    using Services;
    using System;

    public class AddTownCommand : Command
    {
        private TownService townService;

        public AddTownCommand(TownService townService)
        {
            this.townService = townService;
        }
        // AddTown <townName> <countryName>
        public override string Execute(string[] data)
        {
            string townName = data[0];
            string country = data[1];

            if (this.townService.IsTownExisting(townName))
            {
                throw new ArgumentException($"Town {townName} already exists!");
            }

            townService.AddTown(townName,country);
            return townName + " was added to database!";
        }
    }
}
