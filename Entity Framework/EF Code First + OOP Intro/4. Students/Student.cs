namespace _4.Students
{
    class Student
    {
        public Student(string name)
        {
            this.Name = name;
            StudentsCount++;
        }
        public static int StudentsCount { get; set; }
        public string Name { get; set; }
    }
}
