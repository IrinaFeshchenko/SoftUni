namespace BashSoft
{
    public class Launcher
    {
        static void Main()
        {
            Tester tester = new Tester();
            IOManager ioManager = new IOManager();
            StudentRepository repo = new StudentRepository(new RepositoryFilter(), new RepositorySorter());
            CommandInterpreter currentInterpreter = new CommandInterpreter(tester,repo,ioManager);
            InputReader reader = new InputReader(currentInterpreter);

            reader.StartReadingCommands();
        }
    }
}