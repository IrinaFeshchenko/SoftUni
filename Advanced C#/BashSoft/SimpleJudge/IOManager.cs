using System;
using System.IO;

namespace SimpleJudge
{
    public static class IOManager
    {
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
