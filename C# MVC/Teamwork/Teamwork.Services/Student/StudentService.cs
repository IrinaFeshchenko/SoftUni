using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Teamwork.Data.Models;
using Teamwork.Data;

namespace Teamwork.Services.Students
{
    public class StudentService : IStudentService
    {
        private readonly TeamworkDbContext db;

        public StudentService(TeamworkDbContext db)
        {
            this.db = db;
        }

        public async Task<string> GetStudentNumberAsync(string userId) 
            => await this.db
                .Students
                .Where(s => s.UserId == userId)
                .Select(s => s.StudentNumber)
                .FirstOrDefaultAsync();

        public async Task<int> CreateAsync(Student student)
        {
            db.Students.Add(student);
            return await db.SaveChangesAsync();
        }

        public async Task<int?> ChangeStudentNumberAsync(string userId, string studentNumber)
        {
            var student = db.Students
                .FirstOrDefault(s => s.UserId == userId);

            if (student != null)
            {
                student.StudentNumber = studentNumber;
                return await db.SaveChangesAsync();
            }

            return null;
        }
    }
}
