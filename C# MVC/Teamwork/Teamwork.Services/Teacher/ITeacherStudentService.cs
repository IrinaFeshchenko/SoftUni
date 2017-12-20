using System.Collections.Generic;
using System.Threading.Tasks;
using Teamwork.Services.Teacher.Models;

namespace Teamwork.Services.Teacher
{
	public interface ITeacherStudentService
    {
        Task<IEnumerable<TeacherStudentsDto>> AllAsync(string teacherId, string searchTerm = "", int page = 1);

        Task<int> TotalAsync(string searchTerm = "");

        Task<bool> AddStudentToCourseAsync(int courseId, string studentId);
    }
}