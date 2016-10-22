namespace Files
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class FileInfo
    {
        public string Extension { get; set; }
        public long Size { get; set; }
    }

    public class Start
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, FileInfo>> folders = new Dictionary<string, Dictionary<string, FileInfo>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split(';');
                string path = args[0];
                string fileSize = args[1];
                string[] pathArgs = path.Split('\\');
                string rootFolder = pathArgs[0];
                string fileName = pathArgs.Last();
                string fileExtension = fileName.Split('.').Last();

                if (!folders.ContainsKey(rootFolder))
                {
                    folders.Add(rootFolder, new Dictionary<string, FileInfo>());
                }
                if (!folders[rootFolder].ContainsKey(fileName))
                {
                    folders[rootFolder].Add(fileName, new FileInfo());
                }

                FileInfo fileInfo = new FileInfo();
                fileInfo.Extension = fileExtension;
                fileInfo.Size = long.Parse(fileSize);

                folders[rootFolder][fileName] = fileInfo;
            }

            string[] param = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            string extension = param[0];
            string root = param[2];

           

            if (folders.ContainsKey(root))
            {
                var sortedFiles = folders[root]
                                           .Where(x => x.Value.Extension == extension)
                                           .OrderByDescending(x => x.Value.Size)
                                           .ThenBy(x => x.Key);

                if (sortedFiles.Count() > 0)
                {
                    foreach (var file in sortedFiles)
                    {
                        Console.WriteLine($"{file.Key} - {file.Value.Size} KB");
                    }
                }
                else
                {
                    Console.WriteLine("No");
                }

            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
