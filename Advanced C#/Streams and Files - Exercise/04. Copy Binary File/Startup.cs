namespace _04.Copy_Binary_File
{
    using System.IO;

    public class Startup
    {
        static void Main()
        {
            string sourceImagePath = "../../Armageddon.jpg";
            string destinationImagePath = "../../ArmageddonCopy.jpg";
            int readBufferSize = 4098;

            using (FileStream sourceFile = new FileStream(sourceImagePath, FileMode.Open))
            {
                using (FileStream destinationFile = new FileStream(destinationImagePath, FileMode.Create))
                {
                    while (true)
                    {
                        byte[] buffer = new byte[readBufferSize];
                        int readBytes = sourceFile.Read(buffer,0,buffer.Length);

                        if (readBytes == 0)
                        {
                            break;
                        }

                        destinationFile.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
