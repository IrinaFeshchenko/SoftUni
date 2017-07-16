using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Engine
{
    private ConsoleReader inputReader;
    private ConsoleWriter outputWriter;
    private InputParser inputParser;
    private bool isRunning;
    private DraftManager draftManager;

    public Engine()
    {
        this.inputReader = new ConsoleReader();
        this.outputWriter = new ConsoleWriter();
        this.inputParser = new InputParser();
        this.isRunning = true;
        this.draftManager = new DraftManager();
    }

    public void Run()
    {
        while (isRunning)
        {
            var commandParams = inputParser.Parse((inputReader.Readline()));
            this.DispatchCommand(commandParams);
        }
    }

    private void DispatchCommand(List<string> commandParams)
    {
        string command = commandParams[0];
        commandParams.Remove(command);

        if (command== "RegisterHarvester")
        {
            string result = draftManager.RegisterHarvester(commandParams);
            outputWriter.WriteLine(result);
        }
        else if (command == "RegisterProvider")
        {
            string result = draftManager.RegisterProvider(commandParams);
            outputWriter.WriteLine(result);
        }
        else if (command == "Day")
        {
            string result = draftManager.Day();
            outputWriter.WriteLine(result);
        }
        else if (command == "Mode")
        {
            string result = draftManager.Mode(commandParams);
            outputWriter.WriteLine(result);
        }
        else if (command == "Check")
        {
            string result = draftManager.Check(commandParams);
            outputWriter.WriteLine(result);
        }
        else if (command == Constants.INPUT_TERMINATING_COMMAND)
        {
            string result = draftManager.ShutDown();
            outputWriter.WriteLine(result);
            this.isRunning = false;
        }
    }
}
