using System;
using System.IO;
using System.Threading.Tasks;

namespace Slice_File
{
    public class Program
    {
        public static void Main()
        {
            string videoPath = Console.ReadLine();
            string destinaion = Console.ReadLine();
            int pieces = int.Parse(Console.ReadLine());

            SliceAsync(videoPath, destinaion, pieces);

            Console.WriteLine("Anithing else?");
            while (true)
            {
                Console.ReadLine();
            }
        }

        public static void SliceAsync(string sourceFile, string destinaionPath, int parts)
        {
            Task.Run(() =>
            {
                Slice(sourceFile, destinaionPath, parts);
            });
        }

        public static void Slice(string sourceFile, string destinationPath, int parts)
        {
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            using (var source = new FileStream(sourceFile, FileMode.Open))
            {
                FileInfo fileInfo = new FileInfo(sourceFile);

                long partLength = (source.Length / parts) + 1;
                long currentByte = 0;

                for (int currentPart = 1; currentPart <= parts; currentPart++)
                {
                    string filePath = string.Format("{0}/Part-{1}{2}", destinationPath, currentPart, fileInfo.Extension);

                    using (var destination = new FileStream(filePath, FileMode.Create))
                    {
                        int bufferLength = 1024;
                        byte[] buffer = new byte[bufferLength];
                        while (currentByte <= partLength * currentPart)
                        {
                            int readBytesCount = source.Read(buffer, 0, buffer.Length);
                            if (readBytesCount == 0)
                            {
                                break;
                            }

                            destination.Write(buffer, 0, readBytesCount);
                            currentByte += readBytesCount;
                        }
                    }
                }
            }

            Console.WriteLine("Slice complete");
        }      
    }
}
