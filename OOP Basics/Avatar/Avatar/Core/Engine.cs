using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Engine
{
    private ConsoleReader inputReader;
    private ConsoleWriter outputWriter;
    private InputParser inputParser;
    private NationsBuilder nationsBuilder;
    private bool isRunnig;

    public Engine()
    {
        this.inputReader = new ConsoleReader();
        this.outputWriter = new ConsoleWriter();
        this.inputParser = new InputParser();
        this.nationsBuilder = new NationsBuilder();
        this.isRunnig = true;
    }

    public void Run()
    {
        while (this.isRunnig)
        {
            string input = this.inputReader.Readline();
            List<string> commandParams = this.inputParser.Parse(input);
            this.DispatchCommand(commandParams);
        }
    }

    private void DispatchCommand(List<string> commandParams)
    {
        string command = commandParams[0];
        commandParams.Remove(command);

        if (command == "Bender")
        {
            nationsBuilder.AssignBender(commandParams);
        }
        else if (command == "Monument")
        {
            this.nationsBuilder.AssignMonument(commandParams);
        }
        else if (command == "Status")
        {
            string status = this.nationsBuilder.GetStatus(commandParams[0]);
            this.outputWriter.WriteLine(status);
        }
        else if (command == "War")
        {
            this.nationsBuilder.IssueWar(commandParams[0]);
        }
        else if (command == Constants.INPUT_TERMINATING_COMMAND)
        {
            string record = this.nationsBuilder.GetWarsRecord();
            this.outputWriter.WriteLine(record);
            isRunnig = false;
        }
    }
}
