using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    private ConsoleReader inputReadere;
    private ConsoleWriter outputWriter;
    private InputParser inputParser;
    private CarManager carManager;

    public Engine()
    {
        this.inputReadere = new ConsoleReader();
        this.outputWriter = new ConsoleWriter();
        this.inputParser = new InputParser();
        this.carManager = new CarManager();
    }

    public void Run()
    {
        while (true)
        {
            var commandParams = inputParser.Split((inputReadere.Readline()));
            if (commandParams[0] == Constants.INPUT_TERMINATING_COMMAND) break;

            this.DispatchCommand(commandParams);
        }
    }

    private void DispatchCommand(List<string> commandParams)
    {
        string command = commandParams[0];
        commandParams.Remove(command);

        switch (command)
        {
            case "register":
                int registerId = int.Parse(commandParams[0]);
                string registerType = commandParams[1];

                string brand = commandParams[2];
                string model = commandParams[3];
                int yearOfProduction = int.Parse(commandParams[4]);

                int horsepower = int.Parse(commandParams[5]);
                int acceleration = int.Parse(commandParams[6]);
                int suspension = int.Parse(commandParams[7]);
                int durability = int.Parse(commandParams[8]);

                this.carManager.Register(registerId, registerType, brand, model, yearOfProduction, horsepower,
                    acceleration, suspension, durability);
                break;
            case "check":
                int checkId = int.Parse(commandParams[0]);

                this.outputWriter.WriteLine(this.carManager.Check(checkId));
                break;
            case "open":
                int openId = int.Parse(commandParams[0]);
                string openType = commandParams[1];

                int length = int.Parse(commandParams[2]);
                string route = commandParams[3];
                int prizePool = int.Parse(commandParams[4]);

                {
                    this.carManager.Open(openId, openType, length, route, prizePool);
                }

                break;
            case "participate":
                int carId = int.Parse(commandParams[0]);
                int raceId = int.Parse(commandParams[1]);

                this.carManager.Participate(carId, raceId);
                break;
            case "start":
                int startId = int.Parse(commandParams[0]);

                this.outputWriter.WriteLine(this.carManager.Start(startId));
                break;
            case "park":
                int parkId = int.Parse(commandParams[0]);

                this.carManager.Park(parkId);
                break;
            case "unpark":
                int unparkId = int.Parse(commandParams[0]);

                this.carManager.Unpark(unparkId);
                break;
            case "tune":
                int tuneIndex = int.Parse(commandParams[0]);
                string addOn = commandParams[1];

                this.carManager.Tune(tuneIndex, addOn);
                break;
        }
    }
}
