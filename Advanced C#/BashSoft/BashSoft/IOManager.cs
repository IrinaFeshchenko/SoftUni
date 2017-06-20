namespace BashSoft
{
    using System.Collections.Generic;
    using System.IO;

    public static class IOManager
    {
        // BFS directory traversal
        public static void TraverseDirectory(int depth)
        {
            OutputWriter.WriteEmptyLine();
            int initialIdentation = SessionData.currentPath.Split('\\').Length;
            Queue<string> subFolders = new Queue<string>();
            subFolders.Enqueue(SessionData.currentPath);

            while (subFolders.Count !=0)
            {
                string currentPath = subFolders.Dequeue();
                int identation = currentPath.Split('\\').Length - initialIdentation;
                OutputWriter.WriteMessageOnNewLine($"{new string('-', identation)}{currentPath}");

                if (depth - identation < 0)
                {
                    break;
                }

                // get all directories in current directory and enqueue them
                foreach (var directoryPath in Directory.GetDirectories(currentPath))
                {
                    subFolders.Enqueue(directoryPath);
                }

                // display files in directory
                foreach (var file in Directory.GetFiles(currentPath))
                {
                    int indexOflastSlash = file.LastIndexOf("\\");
                    string fileName = file.Substring(indexOflastSlash);
                    OutputWriter.WriteMessageOnNewLine($"{new string('-',indexOflastSlash)}{fileName}");
                }

            }
        }

        public static void CreateDirectoryInCurrentFolder(string name)
        {
            string path = GetCurrentDirectoryPath() + "\\" + name;
            Directory.CreateDirectory(path);
        }

        private static string GetCurrentDirectoryPath()
        {
            return SessionData.currentPath;
        }
    }
}
