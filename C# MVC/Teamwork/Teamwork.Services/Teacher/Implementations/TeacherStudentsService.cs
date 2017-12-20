using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teamwork.Data;
using Teamwork.Data.Models;
using Teamwork.Services.Teacher.Models;
using static Teamwork.Common.GlobalConstants;

namespace Teamwork.Services.Teacher.Implementations
{
    public class TeacherStudentsService : IPagination
    {
        private readonly TeamworkDbContext db;

        public TeacherStudentsService(TeamworkDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<TeacherStudentsDto>> AllAsync(string teacherId, string searchTerm = "", int page = 1)
        {
            var students = db.Users.AsQueryable();

            if (searchTerm != null)
            {
                students = students.Where(u => u.Email.Contains(searchTerm));
            }

            return await students
                        .Select(user => new
                        {
                        Id = user.Id,
                        Email = user.Email,
                        StudentTeacherCourses = (db.StudentCourses.Where(sc => sc.StudentId == user.Id)// get all courses for that student and teacher
                                                .Select(sc => sc.Course))
                                                .Join(
                                                (db.TeacherCourses.Where(tc => tc.TeacherId == teacherId)
                                                .Select(tc => tc.Course)),
                                                sc => sc.Id, tc => tc.Id, (sc, tc) => sc)
                        })
                        .OrderBy(u => u.Email)
                        .Skip((page - 1) * AdminUsersPageSize)
                        .Take(AdminUsersPageSize)
                        .ProjectTo<TeacherStudentsDto>()
                        .ToListAsync();
        }

        public async Task<int> TotalAsync(string searchTerm = "")
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                return await this.db.Users.Where(u => u.Email.Contains(searchTerm)).CountAsync();
            }
            else
            {
                return await this.db.Users.CountAsync();
            }
        }
        
        public async Task<bool> AddStudentToCourseAsync(int courseId, string studentId)
        {
            if (!CourseExists(courseId))
            {
                return false;
            }

            if (!StudentExists(studentId))
            {
                return false;
            }

            await db.StudentCourses.AddAsync(new StudentCourse() { StudentId = studentId, CourseId = courseId });

            var result = await db.SaveChangesAsync();
            if (result <= 0)
            {
                return false;
            }

            return true;
        }

        private bool CourseExists(int id)
        {
            return db.Courses.Any(c =>c.Id == id);
        }

        private bool StudentExists(string id)
        {
            return db.Students.Any(s => s.UserId == id);
        }
    }
}
