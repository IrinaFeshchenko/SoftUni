namespace _05.Slicing_File
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Startup
    {
        static string test = "test";

        static void Main()
        {
            string sourceFilePath = "../../FlickAnimation.avi";
            string destinationDirectory = "../../SlicedFiles/";
            string assembledFilesDir = "../../AssmbledFiles/";
            int parts = 5;

            List<string> fileNames = Slice(sourceFilePath, destinationDirectory, parts);

            Assemble(fileNames, assembledFilesDir);
        }

        private static void Assemble(List<string> files, string assembledFilesDir)
        {
            string assembledFile = $"{assembledFilesDir}assembled.avi";

            if (!Directory.Exists(assembledFilesDir))
            {
                Directory.CreateDirectory(assembledFilesDir);
            }

            using (FileStream writer = new FileStream(assembledFile, FileMode.Append))
            {
                foreach (var fileName in files)
                {
                    using (FileStream reader = new FileStream(fileName, FileMode.Open))
                    {
                        byte[] buffer = new byte[4096];
                        int readBytes;

                        while ((readBytes = reader.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            writer.Write(buffer, 0, readBytes);
                        }
                    }
                }
            }
        }

        private static List<string> Slice(string sourceFilePath, string destinationDirectory, int parts)
        {
            List<string> fileNames = new List<string>();

            using (FileStream reader = new FileStream(sourceFilePath, FileMode.Open))
            {
                var partSize = reader.Length / parts + reader.Length % parts;

                for (int i = 0; i < parts; i++)
                {
                    string filename = $"Part-{i}.avi";
                    string destinationFilePath = $"{destinationDirectory}Part-{i}.avi";
                    fileNames.Add(destinationFilePath);

                    using (FileStream writer = new FileStream(destinationFilePath, FileMode.Create))
                    {
                        byte[] buffer = new byte[partSize];
                        int readBytes = reader.Read(buffer, 0, buffer.Length);
                        writer.Write(buffer, 0, readBytes);
                    }
                }
            }

            return fileNames;
        }
    }
}
