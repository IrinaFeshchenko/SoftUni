namespace BashSoft.IO
{
    using Static_data;
    using System;

    public class InputReader
    {
        private const string endCommand = "quit";

        public static void StartReadingCommands()
        {
            CommandInterpreter.InterpretCommand("readDb dataNew.txt");

            while (true)
            {
                //Interpret command
                OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
                string input = Console.ReadLine().Trim();
                if (input == endCommand) break;

                CommandInterpreter.InterpretCommand(input);
            }
        }
    }
}
