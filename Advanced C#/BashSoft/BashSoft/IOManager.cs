namespace BashSoft
{
    using System;
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

                try
                {
                    // display files in directory
                    foreach (var file in Directory.GetFiles(currentPath))
                    {
                        int indexOflastSlash = file.LastIndexOf("\\");
                        string fileName = file.Substring(indexOflastSlash);
                        OutputWriter.WriteMessageOnNewLine($"{new string('-', indexOflastSlash)}{fileName}");
                    }

                    // get all directories in current directory and enqueue them
                    foreach (var directoryPath in Directory.GetDirectories(currentPath))
                    {
                        subFolders.Enqueue(directoryPath);
                    }

                }
                catch (Exception)
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnauthorizedAccessExceptionMessage);
                }
            }
        }

        public static void CreateDirectoryInCurrentFolder(string name)
        {
            string path = GetCurrentDirectoryPath() + "\\" + name;
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (Exception)
            {
                OutputWriter.DisplayException(ExceptionMessages.ForbiddenSymbolsContainedInName);
            }
        }

        private static string GetCurrentDirectoryPath()
        {
            return SessionData.currentPath;
        }

        public static void ChangeCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath == "..")
            {
                string currentPath = SessionData.currentPath;
                int indexOfLastslash = currentPath.LastIndexOf("\\");
                string newPath = currentPath.Substring(0, indexOfLastslash);
                SessionData.currentPath = newPath;
            }
            else
            {
                string currentPath = SessionData.currentPath;
                currentPath += "\\" + relativePath;
                ChangeCurrentDirectoryAbsolute(currentPath);
            }
        }

        public static void ChangeCurrentDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
                return;
            }

            SessionData.currentPath = absolutePath;
        }
    }
}
