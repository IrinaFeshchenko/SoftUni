using System.Collections.Generic;
using System.Threading.Tasks;
using Teamwork.Services.Teacher.Models;

namespace Teamwork.Services.Teacher
{
    public interface ITeacherCoursesService
    {
        Task<IEnumerable<TeacherCourseDto>> AllAsync(string teacherId, string searchTerm, int page);

        Task<bool> CreateAsync(string creatorId, TeacherCourseCreateDto course);
        
        Task<TeacherCourseDto> GetByIdAsync(int? id);
        
        Task<bool> UpdateAsync(string teacherId, TeacherCourseDto course);
        
        Task<bool> DeleteAsync(int id);

        Task<int> TotalAsync(string searchTerm = "");
    }
}
