using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Teamwork.Data.Models;
using Teamwork.Services.Teacher.Implementations;
using Teamwork.Web.Areas.Teachers.Controllers;
using Xunit;
using static Teamwork.Common.GlobalConstants;

namespace Teamwork.Test.Web.Areas.Teachers.Controllers
{
    public class StudentsControllerTests
    {
        private readonly TestHelpers testHelpers;
        public StudentsControllerTests()
        {
            //TestInit.InitializeMapper();
            testHelpers = new TestHelpers();
        }

        [Fact]
        public void StudentsControllerAccessibleForTeachersAndAdministratorsOnly()
        {
            // Arrange
            var classType = typeof(BaseTeachersController);

            // Act
            var attributes = classType.GetCustomAttributes(true);
            var attr = attributes.Where(a => a.GetType() == typeof(AuthorizeAttribute)).FirstOrDefault();
            var roles = (attr as AuthorizeAttribute).Roles.Split(",", System.StringSplitOptions.RemoveEmptyEntries).Select(r=>r.Trim());

            // Assert
            Assert.Contains(attributes, a => a.GetType() == typeof(AuthorizeAttribute));
            Assert.Contains(roles, r => r == AdministratorRole);
            Assert.Contains(roles, r => r == TeacherRole);
            Assert.DoesNotContain(roles, r => r != AdministratorRole && r!= TeacherRole);
        }

        [Fact]
        public async Task AddToCourseShouldAddStudentToCourse()
        {
            // Arrange
            var db = TestInit.InitializeInmemoryDatabase();
            var teacherCoursesService = new TeacherCoursesService(db);
            var teacherStudentsService = new TeacherStudentsService(db);
            var userManager = testHelpers.GetUserManagerMock();
            var roleManager = testHelpers.GetRoleManagerMock();         
            var usersController = new StudentsController(teacherStudentsService, teacherCoursesService, userManager, roleManager);
            usersController.TempData = new TempDataDictionary(Mock.Of<HttpContext>(), Mock.Of<ITempDataProvider>());

            string studentId = "1";
            int courseId = 1;
            db.Courses.Add(new Course { Id = courseId, Name = "Course" });
            db.Students.Add(new Student { UserId = studentId});
            await db.SaveChangesAsync();

            // Act
            var result = await usersController.AddToCourse(studentId, courseId.ToString());

            // Assert
            Assert.Contains(db.StudentCourses, sc => sc.StudentId == studentId && sc.CourseId == courseId);
        }
    }
}
