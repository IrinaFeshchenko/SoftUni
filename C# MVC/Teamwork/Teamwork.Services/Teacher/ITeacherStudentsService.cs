using System.Collections.Generic;
using System.Threading.Tasks;
using Teamwork.Services.Teacher.Models;

namespace Teamwork.Services.Teacher
{
	public interface ITeacherStudentsService
    {
        Task<IEnumerable<TeacherStudentsDto>> AllAsync(string teacherId, string searchTerm = "", int page = 1);

        Task<int> TotalAsync(string searchTerm = "");

        Task<bool> AddStudentToCourseAsync(string userId, int courseId);

        Task<bool> RemoveStudentFromCourseAsync(string userId, int courseId);
    }
}