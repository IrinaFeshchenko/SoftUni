namespace BashSoft
{
    public class Launcher
    {
        static void Main()
        {

            IOManager.ChangeCurrentDirectoryAbsolute(@"c:\windows");
            IOManager.TraverseDirectory(20);
        }
    }
}
