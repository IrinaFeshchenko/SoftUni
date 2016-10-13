namespace FolderSize
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Start
    {
        public static void Main()
        {
            string folder = "TestFolder";
            string resultFile = "result.txt";

            var files = Directory.GetFiles(folder);

            double sum = 0;
            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                sum += fileInfo.Length;
            }

            sum = sum / 1024 / 1024;

            File.WriteAllText(resultFile, sum.ToString());
        }
    }
}
