
namespace BashSoft
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class InputReader
    {
        private const string endCommand = "quit";

        public static void StartReadingCommands()
        {
            while (true)
            {
                //Interpret command
                OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
                string input = Console.ReadLine().Trim();
                if (input == endCommand) break;

                InterpretCommand(input);
            }
        }

        public static void InterpretCommand(string input)
        {
            string[] data = input.Split(' ');
            string command = data[0];

            if (command == "open")
            {
                if (data.Length == 2)
                {
                    TryOpenFile(input, data);
                }
            }
            else if (command == "mkdir")
            {
                if (data.Length == 2)
                {
                    TryCreateDirectory(input, data);
                }
            }
            else if (command == "ls")
            {
                if (data.Length == 1)
                {
                    IOManager.TraverseDirectory(0);
                }
                else if (data.Length == 2)
                {
                    int depth;
                    bool hasParsed = int.TryParse(data[1], out depth);
                    if (hasParsed)
                    {
                        IOManager.TraverseDirectory(depth);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.UnableToParseNumber);
                    }
                }
            }
            else if (command == "cmp")
            {
                if (data.Length == 3)
                {
                    string firstPath = data[1];
                    string secondPath = data[2];

                    Tester.CompareContent(firstPath, secondPath);
                }
            }
            else if (command == "cdRel")
            {
                if (data.Length == 2)
                {
                    string relPath = data[1];
                    IOManager.ChangeCurrentDirectoryRelative(relPath);
                }
            }
            else if (command == "cdAbs")
            {
                if (data.Length == 2)
                {
                    string absPath = data[1];
                    IOManager.ChangeCurrentDirectoryAbsolute(absPath);
                }
            }
            else if (command == "readDb")
            {
                if (data.Length == 2)
                {
                    string fileName = data[1];
                    StudentsRepository.InitializeData(fileName);
                }
            }
            else if (command == "help")
            {
                if (data.Length == 1)
                {
                    OutputWriter.WriteEmptyLine();
                    OutputWriter.WriteMessage(DisplayHelp());
                    OutputWriter.WriteEmptyLine();
                }
            }
            else if (command == "filter")
            {

            }
            else if (command == "order")
            {

            }
            else if (command == "decOrder")
            {

            }
            else if (command == "download")
            {

            }
            else if (command == "downloadAsynch")
            {

            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidCommand);
            }
        }

        private static string DisplayHelp()
        {
            return @"•	mkdir directoryName – create a directory in the current directory
•	ls (depth) – traverse the current directory to the given depth
•	cmp absolutePath1 absolutePath2 – comparing two files by given two absolute paths
•	changeDirRel relativePath – change the current directory by a relative path
•	changeDirAbs absolutePath – change the current directory by an absolute path
•	readDb dataBaseFileName – read students database by a given name of the database file which is placed in the current folder
•	filter courseName poor/average/excellent take 2/10/42/all – filter students from а given course by a given filter option and add quantity for the number of students to take or all if you want to take all the students matching the current filter option
•	order courseName ascending/descending take 3/26/52/all – order student from a given course by ascending or descending order and then taking some quantity of the filter or all that match it
•	download (path of file) – download a file
•	downloadAsynch: (path of file) – download file asinchronously
•	help – get help
•	open – opens a file
";
        }

        private static void TryOpenFile(string input, string[] data)
        {
            string fileName = data[1];
            Process.Start(SessionData.currentPath + "\\" + fileName);
        }

        private static void TryCreateDirectory(string input, string[] data)
        {
            string folderName = data[1];
            IOManager.CreateDirectoryInCurrentFolder(folderName);
        }
    }
}
