namespace OddLines
{
    using System.Linq;
    using System.IO;

    public class Start
    {
        public static void Main()
        {
            string inputFile = "input.txt";
            string outputFile = "output.txt";

            string[] textLines = File.ReadAllLines(inputFile);
            File.WriteAllLines(outputFile,textLines.Where((line,index)=>index%2 ==1));
        }
    }
}
