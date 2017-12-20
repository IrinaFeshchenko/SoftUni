using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teamwork.Data.Models;
using Teamwork.Services.Teacher.Models;
using Teamwork.Data;
using static Teamwork.Common.GlobalConstants;
using System;
using Z.EntityFramework.Plus;

namespace Teamwork.Services.Teacher.Implementations
{
    public class TeacherCoursesService : ITeacherCoursesService, IFilterablePagination
    {
        private readonly TeamworkDbContext db;

        public TeacherCoursesService(TeamworkDbContext db)
        {
            this.db = db;
        }

        // Get all for current Id (ManyToMany)
        public async Task<IEnumerable<TeacherCourseDto>> AllAsync(string teacherId = null, string searchTerm = "", int page = 1)
        {
            var courses = db.Courses.AsQueryable();

            if (teacherId != null)
            {
                courses = courses
                        .Where(c =>
                        c.TeachersCourses.Any(tc => tc.TeacherId == teacherId));
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                courses = courses
                        .Where(c => c.Name.Contains(searchTerm));
            }

            return await courses
                        .OrderBy(c => c.Name)
                        .Skip((page - 1) * TeacherCoursesPageSize)
                        .Take(AdminUsersPageSize)
                        .ProjectTo<TeacherCourseDto>()
                        .ToListAsync();
        }

        // Create by Model
        public async Task<bool> CreateAsync(string userId, TeacherCourseCreateDto course)
        {
            if (course == null)
            {
                return false;
            }

            // Get the course teacher
            var teacher = db.Teachers.Find(userId);
            if (teacher == null)
            {
                return false;
            }

            // create the new course
            var newCourse = Mapper.Map<TeacherCourseCreateDto, Course>(course,opt => opt.ConfigureMap(MemberList.None));
            db.Courses.Add(newCourse);

            // add the teacher for the new course
            var teacherForCourse = new TeacherCourse { Teacher = teacher, Course = newCourse};
            db.TeacherCourses.Add(teacherForCourse);
            
            var result = await db.SaveChangesAsync();
            if (result <= 0)
            {
                return false;
            }

            return true;
        }

        // Get Model by Id
        public async Task<TeacherCourseDto> GetByIdAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var course = await db.Courses.ProjectTo<TeacherCourseDto>()
                                .SingleOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return null;
            }

            return course;
        }

        // Update Model by Id
        public async Task<bool> UpdateAsync(string teacherId, TeacherCourseDto courseDto)
        {
            if (courseDto == null)
            {
                return false;
            }

            var dbCourse = db.Courses.Find(courseDto.Id);
            if (dbCourse == null)
            {
                return false;
            }

            // The teacher can only edit his courses
            var TeacherForCourse = db.TeacherCourses.Find(teacherId, dbCourse.Id);
            if (TeacherForCourse == null)
            {
                return false;
            }

            try
            {
                dbCourse.Name = courseDto.Name;
                dbCourse.Description = courseDto.Description;
                db.Courses.Update(dbCourse);
                var result = await db.SaveChangesAsync();
                if (result <= 0)
                {
                    return false;
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(courseDto.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        // Delete Model by Id
        public async Task<bool> DeleteAsync(string teacherId, int id)
        {
            if (!CourseExists(id))
            {
                return false;
            }

            // Get the course teacher
            var teacher = db.Teachers.Find(teacherId);
            if (teacher == null)
            {
                return false;
            }

            // If theacher is teaching in the course 
            var course = await db.Courses.SingleOrDefaultAsync(m => m.Id == id && db.TeacherCourses.Any(tc => (tc.CourseId == m.Id)&&(tc.TeacherId == teacherId)));
            if (course == null)
            {
                return false;
            }

            await db.StudentCourses.Where(sc => sc.CourseId == id).DeleteAsync();
            await db.TeacherCourses.Where(tc => tc.CourseId == id).DeleteAsync();

            var result = await db.Courses.Where(c => c.Id == id).DeleteAsync();
            if (result <= 0)
            {
                return false;
            }

            return true;
        }

        // Check if the recordExists
        private bool CourseExists(int id)
        {
            return db.Courses.Any(e => e.Id == id);
        }

        // Total number of items for searchTerm (used for pagination)
        public async Task<int> TotalAsync(string teacherId = null, string searchTerm = "")
        {
            var courses = db.Courses.AsQueryable();

            if (teacherId != null)
            {
                courses = courses.Where(c =>
                        c.TeachersCourses.Any(tc => tc.TeacherId == teacherId));
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {

                courses = courses.Where(c => 
                        c.Name.Contains(searchTerm));
            }

            return await courses.Select(c => c.Id).CountAsync();
        }
    }
}
