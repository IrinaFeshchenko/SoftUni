namespace _06.Zipping_Sliced_Files
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;

    public class Startup
    {
        static void Main()
        {
            string sourceFilePath = "../../FlickAnimation.avi";
            string destinationDirectory = "../../SlicedZippedFiles/";
            string assembledFilesDir = "../../AssmbledUnzippedFiles/";
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

            using (var writer = new FileStream(assembledFile, FileMode.Append))
            {
                foreach (var fileName in files)
                {
                    using (var reader = new FileStream(fileName, FileMode.Open))
                    using (var gzipReader = new GZipStream(reader, CompressionMode.Decompress))
                    {
                        byte[] buffer = new byte[4096];
                        int readBytes;

                        while ((readBytes = gzipReader.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            writer.Write(buffer, 0, readBytes);
                        }
                    }
                }
            }
        }

        private static List<string> Slice(string sourceFilePath, string destinationDirectory, int parts)
        {
            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            var fileNames = new List<string>();

            using (var reader = new FileStream(sourceFilePath, FileMode.Open))
            {
                var partSize = reader.Length / parts + reader.Length % parts;

                for (int i = 0; i < parts; i++)
                {
                    string filename = $"Part-{i}.avi";
                    string destinationFilePath = $"{destinationDirectory}Part-{i}.zip";
                    fileNames.Add(destinationFilePath);

                    using (var writer = new FileStream(destinationFilePath, FileMode.Create))
                    using (var gzipWriter = new GZipStream(writer,CompressionMode.Compress))
                    {
                        byte[] buffer = new byte[partSize];
                        int readBytes = reader.Read(buffer, 0, buffer.Length);
                        gzipWriter.Write(buffer, 0, readBytes);
                    }
                }
            }

            return fileNames;
        }
    }
}
