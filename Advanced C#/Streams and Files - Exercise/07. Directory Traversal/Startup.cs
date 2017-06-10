namespace _07.Directory_Traversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            var directoryName = "../../";
            var extensions = new []{ ".cs",".txt",".asm",".js",".config" };
            var outputFilename = "report.txt";

            var fileNames = TraverseDirectory(directoryName, extensions);

            SaveToFile(outputFilename, fileNames);
        }

        private static void SaveToFile(string outputFilename, IEnumerable<string> fileNames)
        {
            var sorted = fileNames.GroupBy(f => Path.GetExtension(f))
                                  .OrderByDescending(f=>f.Count())
                                  .ThenBy(f=>f.Key);

            using (var writer = new FileStream(outputFilename, FileMode.Create))
            {
                foreach (var fileGroup in sorted)
                {
                    Console.WriteLine(fileGroup.Key);

                    foreach (var file in fileGroup)
                    {
                        Console.WriteLine($"--{Path.GetFileName(file)} - {(new FileInfo(file).Length)/1024f:0.###}kb");
                    }
                }
            }
        }

        private static IEnumerable<string> TraverseDirectory(string directoryName, string[] extensions)
        {
            var fileNames = Directory.GetFiles(directoryName, "*.*", SearchOption.AllDirectories)
                                     .Where(f => extensions.Contains(Path.GetExtension(f)));

            return fileNames;
        }
    }
}
