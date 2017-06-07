namespace _02.Line_Numbers
{
    using System.IO;

    public class Startup
    {
        static void Main()
        {
            using (StreamReader reader = new StreamReader("../../InputTextFile.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../OutputTextFile.txt"))
                {
                    string line = string.Empty;
                    int lineNumber = 0;

                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine($"{lineNumber++} {line}");
                    }
                }
            }
        }
    }
}
