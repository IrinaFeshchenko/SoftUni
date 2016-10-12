

namespace Files
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    public class File
    {
        public string name { get; set; }
        public ulong size { get; set; }
    }

    public class Start
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<File> files = ReadInput(n);

            string[] args = Console.ReadLine().Split();
            string extension = "." + args[0];
            string directory = args[2];
            string p = Path.GetPathRoot(@"E:\Movies\Classics\someclassicmovie.avi");
            List<File> filteredFiles = new List<File>();

            foreach (var file in files)
            {
                if ((Root(file) == directory) &&
                    (Extension(file) == extension))
                {
                    FileName(file);
                    File duplicate = new File();
                    foreach (var f in filteredFiles)
                    {
                        string n1 = FileName(f);
                        string n2 = FileName(file);
                        if (n1 == n2)
                        {
                            filteredFiles.Remove(f);
                            break;
                        }
                    }

                    filteredFiles.Add(file);
                }
            }

            if (filteredFiles.Count() == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                var result = filteredFiles
                    .OrderByDescending(f => f.size)
                    .ThenBy(f => f.name);

                foreach (var file in result)
                {
                    string fileName = Path.GetFileName(file.name);
                    ulong fileSize = file.size;
                    Console.WriteLine($"{fileName} - {fileSize} KB");
                }
            }
        }

        private static string FileName(File f)
        {
            string fileName = Path.GetFileName(f.name);
            return fileName;
        }

        private static string Extension(File file)
        {
            string extension = Path.GetExtension(file.name);
            return extension;
        }

        private static string Root(File f)
        {
            int lenght = f.name.IndexOf("\\");
            int start = 0;
            string root = f.name.Substring(start, lenght);
            return root;
        }

        private static List<File> ReadInput(int n)
        {
            List<File> files = new List<File>();

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split(';');
                File file = new File()
                {
                    name = args[0],
                    size = ulong.Parse(args[1])
                };

                files.Add(file);
            }
            return files;
        }
    }
}
