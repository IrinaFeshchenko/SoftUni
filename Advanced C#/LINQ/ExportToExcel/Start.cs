

namespace ExportToExcel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using ExcelLibrary.SpreadSheet;

    public class Student
    {
        public int FacultyNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int Group { get; set; }
        public int Grade1 { get; set; }
        public int Grade2 { get; set; }
        public int Grade3 { get; set; }
        public int Grade4 { get; set; }
        public string Phone { get; set; }
    }

    class Start
    {
        public static void Main()
        {
            List<Student> students = ReadDataSet();
            SaveToExcel(students);
            Console.WriteLine("Succesfully converted the data from StudentData.txt to StudentData.xls");
            Console.WriteLine("Browse the project folder to find the created file");
        }

        private static void SaveToExcel(List<Student> students)
        {
            // create workbook and write data from students class
            Workbook workbook = new Workbook();
            Worksheet worksheet = new Worksheet("Students Data");

            int iRow = 0;
            foreach (var student in students)
            {
                iRow++;
                worksheet.Cells[iRow, 1] = new Cell(student.FacultyNumber);
                worksheet.Cells[iRow, 2] = new Cell(student.FirstName);
                worksheet.Cells[iRow, 3] = new Cell(student.LastName);
                worksheet.Cells[iRow, 4] = new Cell(student.Email);
                worksheet.Cells[iRow, 5] = new Cell(student.Age);
                worksheet.Cells[iRow, 6] = new Cell(student.Group);
                worksheet.Cells[iRow, 7] = new Cell(student.Grade1);
                worksheet.Cells[iRow, 8] = new Cell(student.Grade2);
                worksheet.Cells[iRow, 9] = new Cell(student.Grade3);
                worksheet.Cells[iRow, 10] = new Cell(student.Grade4);
                worksheet.Cells[iRow, 11] = new Cell(student.Phone);
                worksheet.Cells.ColumnWidth[0, 1] = 3000;
            }
            workbook.Worksheets.Add(worksheet);

            // Bug on Excel Library, min file size must be 7 Kb
            // thus we need to add empty row for safety
            if (iRow<100)
            {
                Worksheet ws = new Worksheet("sheet X");
                for (int i = 0; i < 100; i++)
                {
                    ws.Cells[i, 0] = new Cell(" ");
                }
                workbook.Worksheets.Add(ws);
            }

            // write workbook to file
            string fileName = "StudentData.xls";
            string directoryName = @"..\..\";
            string path = Path.Combine(directoryName, fileName);
            workbook.Save(path);
        }

        private static List<Student> ReadDataSet()
        {
            // open file and put data in Students class
            List<Student> students = new List<Student>();
            string fileName = "StudentData.txt";
            string directoryName = @"..\..\";
            string path = Path.Combine(directoryName, fileName);

            try
            {
                string[] file = File.ReadAllLines(path);

                foreach (var row in file.Skip(1))
                {
                    string[] args = row.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    Student student = new Student()
                    {
                        FacultyNumber = int.Parse(args[0]),
                        FirstName = args[1],
                        LastName = args[2],
                        Email = args[3],
                        Age = int.Parse(args[4]),
                        Group = int.Parse(args[5]),
                        Grade1 = int.Parse(args[6]),
                        Grade2 = int.Parse(args[7]),
                        Grade3 = int.Parse(args[8]),
                        Grade4 = int.Parse(args[9]),
                        Phone = args[10],
                    };
                    students.Add(student);
                }
            }
            catch (DirectoryNotFoundException)
            {
                Error("Directory was not found");
            }
            catch (FileNotFoundException)
            {
                Error("File was not found");
            }

            return students;
        }

        private static void Error(string message)
        {
            Console.WriteLine(message);
        }
    }
}
