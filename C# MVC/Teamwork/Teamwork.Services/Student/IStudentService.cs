using System.Threading.Tasks;
using Teamwork.Data.Models;

namespace Teamwork.Services.Students
{
	public interface IStudentService
    {
        Task<string> GetStudentNumberAsync(string userId);

        Task<int> CreateAsync(Student student);

        Task<int?> ChangeStudentNumberAsync(string userId, string studentNumber);
    }
}