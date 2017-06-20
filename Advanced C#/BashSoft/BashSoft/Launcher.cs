namespace BashSoft
{
    public class Launcher
    {
        static void Main()
        {
            StudentsRepository.InitializeData();
            StudentsRepository.GetStudentScoresFromCourse("Unity","Ivan");
        }
    }
}
