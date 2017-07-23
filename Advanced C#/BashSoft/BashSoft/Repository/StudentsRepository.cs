using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace BashSoft
{
    public class StudentRepository
    {
        private bool isDataInilized = false;
        private RepositoryFilter filter;
        private RepositorySorter sorter;
        //private Dictionary<string, Dictionary<string, List<int>>> studentByCourse;
        private Dictionary<string, Course> courses;
        private Dictionary<string, Student> students;

        public StudentRepository(RepositoryFilter filter, RepositorySorter sorter)
        {
            this.filter = filter;
            this.sorter = sorter;
            //this.studentByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
        }

        public void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].studentsByName.Count;
                }

                Dictionary<string, double> marks = this.courses[courseName]
                    .studentsByName
                    .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);

                this.sorter.OrderAndTake(marks, givenFilter, studentsToTake.Value);
            }
        }

        public void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].studentsByName.Count;
                }

                Dictionary<string, double> marks = this.courses[courseName]
                    .studentsByName
                    .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);

                this.sorter.OrderAndTake(marks, comparison, studentsToTake.Value);
            }
        }

        public void LoadData(string fileName)
        {
            if (this.isDataInilized)
            {
                throw new InvalidOperationException(ExceptionMessages.DataAlreadyInitialisedException);
                return;
            }
            this.students = new Dictionary<string, Student>();
            this.courses = new Dictionary<string, Course>();
            ReadData(fileName);
            OutputWriter.WriteMessageOnNewLine("Reading data...");
        }

        public void UnloadData()
        {
            if (!this.isDataInilized)
            {
                throw new ArgumentException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            this.students = null;
            this.courses = null;
            //this.studentByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
            this.isDataInilized = false;
        }

        private void ReadData(string fileName)
        {
            string path = SessionData.currentPath + "\\" + fileName;
            if (File.Exists(path))
            {
                //var rgx = new Regex(@"([A-Z][A-Za-z+#]*_[A-Z][a-z]{2}_201[4-9])\s+([A-Z][a-z]{0,3}\d{2}_\d{2,4})\s+(\d{1,3})");
                var rgx = new Regex(@"([A-Z][a-zA-Z#\++]*_[A-Z][a-z]{2}_\d{4})\s+([A-Za-z]+\d{2}_\d{2,4})\s([\s0-9]+)");
                var allInputLines = File.ReadAllLines(path);
                for (int i = 0; i < allInputLines.Length; i++)
                {
                    if (!string.IsNullOrEmpty(allInputLines[i]) && rgx.IsMatch(allInputLines[i]))
                    {
                        var currentMatch = rgx.Match(allInputLines[i]);
                        var courseName = currentMatch.Groups[1].Value;
                        var studentName = currentMatch.Groups[2].Value;
                        string scoresStr = currentMatch.Groups[3].Value;
                        try
                        {
                            int[] scores = scoresStr.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                               .Select(int.Parse)
                                               .ToArray();

                            if (scores.Length > Course.NumberOfTasksOnExam)
                            {
                                throw new ArgumentOutOfRangeException(ExceptionMessages.InvalidNumberOfScores);
                            }

                            if (!this.students.ContainsKey(studentName))
                            {
                                this.students.Add(studentName, new Student(studentName));
                            }

                            if (!this.courses.ContainsKey(courseName))
                            {
                                this.courses.Add(courseName, new Course(courseName));
                            }

                            Course course = this.courses[courseName];
                            Student student = this.students[studentName];

                            student.EnrollInCourse(course);
                            student.SetMarkOnCourse(courseName, scores);

                            course.EnrollStudent(student);
                        }
                        catch (Exception fex)
                        {
                            string msg = fex.Message ;
                            throw new ArgumentException(fex.Message + $"at line: ");
                        }

                        //int score;
                        //var hasParsed = int.TryParse(currentMatch.Groups[3].Value, out score);

                        //if (hasParsed && score <= 100 && score >= 0)
                        //{
                        //    if (!studentByCourse.ContainsKey(course))
                        //    {
                        //        studentByCourse.Add(course, new Dictionary<string, List<int>>());
                        //    }

                        //    if (!studentByCourse[course].ContainsKey(student))
                        //    {
                        //        studentByCourse[course].Add(student, new List<int>());
                        //    }

                        //    studentByCourse[course][student].Add(score);
                        //}
                    }
                }
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPath);
                return;
            }

            isDataInilized = true;
            OutputWriter.WriteMessageOnNewLine("Data read!");
        }

        private bool IsQueryForCoursePossible(string courseName)
        {
            if (isDataInilized)
            {
                if (this.courses.ContainsKey(courseName))
                {
                    return true;
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            return false;
        }

        private bool IsQueryForStudentPossible(string courseName, string studentUserName)
        {
            if (IsQueryForCoursePossible(courseName) && this.courses[courseName].studentsByName.ContainsKey(studentUserName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
            }

            return false;
        }

        public void GetStudentScoresFromCourse(string courseName, string username)
        {
            OutputWriter.PrintStudent(new KeyValuePair<string, double>
                (username, this.courses[courseName].studentsByName[username]
                .MarksByCourseName[courseName]));
        }

        public void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}");
                foreach (var studentsMarksEntry in this.courses[courseName].studentsByName)
                {
                    this.GetStudentScoresFromCourse(courseName, studentsMarksEntry.Key);
                }
            }
        }
    }
}