namespace MergeFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Start
    {
        public static void Main()
        {
            string file1 = "FileOne.txt";
            string file2 = "FileTwo.txt";
            string output = "output.txt";

            string[] text1 = File.ReadAllLines(file1);
            string[] text2 = File.ReadAllLines(file2);

            var result = text1.Zip(text2,(x,y)=> new string[] { x,y}).SelectMany(s=>s);

            File.WriteAllLines(output, result);
        }
    }
}
