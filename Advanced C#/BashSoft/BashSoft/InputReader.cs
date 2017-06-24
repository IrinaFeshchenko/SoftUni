
namespace BashSoft
{
    using System;

    public class InputReader
    {
        private const string endCommand = "quit";

        public static void StartReadingCommands()
        {
            InputReader.InterpretCommand("readDb dataNew.txt");

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
                TryOpenFile(data);
            }
            else if (command == "mkdir")
            {
                TryCreateDirectory(data);
            }
            else if (command == "ls")
            {
                TryTraverseDIrectory(data);
            }
            else if (command == "cmp")
            {
                TryCompare(data);
            }
            else if (command == "cdRel")
            {
                TryChangeDirectoryRelativePath(data);
            }
            else if (command == "cdAbs")
            {
                TryChangeDirectoryAbsolutePath(data);
            }
            else if (command == "readDb")
            {
                TryReadDB(data);
            }
            else if (command == "help")
            {
                TryShowHelp(data);
            }
            else if (command == "show")
            {
                TryShowWantedData(data);
            }
            else if (command == "filter")
            {
                TryFilterAndTake(data);
            }
            else if (command == "order")
            {
                TryOrderAndTake(data);
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

        private static void TryOrderAndTake(string[] data)
        {
            if (data.Length == 5)
            {
                string courseName = data[1];
                string comparison = data[2].ToLower();
                string takeCommand = data[3].ToLower();
                string takeQuantity = data[4].ToLower();

                TryParseParametersForOrderAndTake(takeCommand, takeQuantity, courseName, comparison);
            }
        }

        private static void TryParseParametersForOrderAndTake(string takeCommand, string takeQuantity, string courseName, string comparison)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    StudentsRepository.OrderAndTake(courseName, comparison);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                    if (hasParsed)
                    {
                        StudentsRepository.OrderAndTake(courseName, comparison, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
            }
        }

        private static void TryFilterAndTake(string[] data)
        {
            if (data.Length == 5)
            {
                string courseName = data[1];
                string filter = data[2].ToLower();
                string takeCommand = data[3].ToLower();
                string takeQuantity = data[4].ToLower();

                TryParseParametersForFilterAndTake(takeCommand, takeQuantity, courseName, filter);
            }
        }

        private static void TryParseParametersForFilterAndTake(string takeCommand, string takeQuantity, string courseName, string filter)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    StudentsRepository.FilterAndTake(courseName, filter);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                    if (hasParsed)
                    {
                        StudentsRepository.FilterAndTake(courseName, filter, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
            }
        }

        private static void TryShowHelp(string[] data)
        {
            if (data.Length == 1)
            {
                OutputWriter.WriteEmptyLine();
                OutputWriter.WriteMessage(DisplayHelp());
                OutputWriter.WriteEmptyLine();
            }
        }

        private static void TryReadDB(string[] data)
        {
            if (data.Length == 2)
            {
                string fileName = data[1];
                StudentsRepository.InitializeData(fileName);
            }
        }

        private static void TryChangeDirectoryAbsolutePath(string[] data)
        {
            if (data.Length == 2)
            {
                string absPath = data[1];
                IOManager.ChangeCurrentDirectoryAbsolute(absPath);
            }
        }

        private static void TryChangeDirectoryRelativePath(string[] data)
        {
            if (data.Length == 2)
            {
                string relPath = data[1];
                IOManager.ChangeCurrentDirectoryRelative(relPath);
            }
        }

        private static void TryCompare(string[] data)
        {
            if (data.Length == 3)
            {
                string firstPath = data[1];
                string secondPath = data[2];

                Tester.CompareContent(firstPath, secondPath);
            }
        }

        private static void TryTraverseDIrectory(string[] data)
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

        private static void TryShowWantedData(string[] data)
        {
            if (data.Length == 2)
            {
                string courseName = data[1];
                StudentsRepository.GetAllStudentsFromCourse(courseName);
            }
            else if (data.Length == 3)
            {
                string courseName = data[1];
                string userName = data[2];
                StudentsRepository.GetStudentScoresFromCourse(courseName, userName);
            }
        }

        private static string DisplayHelp()
        {
            return @"•	mkdir directoryName – create a directory in the current directory
•	ls (depth) – traverse the current directory to the given depth
•	cmp absolutePath1 absolutePath2 – comparing two files by given two absolute paths
•	cdRel relativePath – change the current directory by a relative path
•	cdAbs absolutePath – change the current directory by an absolute path
•	readDb dataBaseFileName – read students database by a given name of the database file which is placed in the current folder
•	filter courseName poor/average/excellent take 2/10/42/all – filter students from а given course by a given filter option and add quantity for the number of students to take or all if you want to take all the students matching the current filter option
•	order courseName ascending/descending take 3/26/52/all – order student from a given course by ascending or descending order and then taking some quantity of the filter or all that match it
•	download (path of file) – download a file
•	downloadAsynch: (path of file) – download file asinchronously
•	help – get help
•	open – opens a file
";
        }

        private static void TryOpenFile(string[] data)
        {
            if (data.Length == 2)
            {
                string fileName = data[1];
                Process.Start(SessionData.currentPath + "\\" + fileName);
            }
        }

        private static void TryCreateDirectory(string[] data)
        {
            if (data.Length == 2)
            {
                string folderName = data[1];
                IOManager.CreateDirectoryInCurrentFolder(folderName);
            }
        }
    }
}
