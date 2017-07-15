using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Engine
{
    private ConsoleReader inputReader;
    private ConsoleWriter outputWriter;
    private InputParser inputParser;
    //private CarManager carManager;
    //private CarFactory carFactory;
    //private RaceFactory raceFactory;

    public Engine()
    {
        this.inputReader = new ConsoleReader();
        this.outputWriter = new ConsoleWriter();
        this.inputParser = new InputParser();

        //this.carFactory = new CarFactory();
        //this.raceFactory = new RaceFactory();
        //this.carManager = new CarManager(carFactory, raceFactory);
    }

    public void Run()
    {
        while (true)
        {
            var commandParams = inputParser.Parse((inputReader.Readline()));
            if (commandParams[0] != Constants.INPUT_TERMINATING_COMMAND) break;

            this.DispatchCommand(commandParams);
        }
    }

    private void DispatchCommand(List<string> commandParams)
    {
        string command = commandParams[0];
        commandParams.Remove(command);

        switch (command)
        {

        }
    }
}
