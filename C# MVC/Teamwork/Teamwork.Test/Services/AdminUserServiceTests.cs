using System.Threading.Tasks;
using Teamwork.Data.Models;
using Teamwork.Services.Admin;
using Xunit;
using System.Linq;

namespace Teamwork.Test.Services
{
    public class AdminUserServiceTests
    {
        public AdminUserServiceTests()
        {
            TestInit.InitializeMapper();
        }

        [Fact]
        public async Task FindAsyncShouldReturnCorrectResultCount()
        {
            // Arrange
            var db = TestInit.InitializeInmemoryDatabase();
            var user1 = new User() { Id = "1", FirstName = "user1f", Surname = "user1s", Email = "user1@bu.com" };
            var user2 = new User() { Id = "2", FirstName = "user2f", Surname = "user2s", Email = "user2@bu.com" };
            var user3 = new User() { Id = "3", FirstName = "user3f", Surname = "user3s", Email = "user3@bu.com" };

            db.AddRange(user1, user2, user3);
            await db.SaveChangesAsync();

            var adminUserService = new AdminUserService(db);

            // Act
            var result = await adminUserService.AllAsync();

            // Assert
            Assert.True(result.Count() == 3);
        }

        [Fact]
        public async Task FindAsyncShouldReturnCorrectResultSearchCount()
        {
            // Arrange
            var db = TestInit.InitializeInmemoryDatabase();
            var user1 = new User() { Id = "1", FirstName = "user1f", Surname = "user1s", Email = "user1@bu.com" };
            var user2 = new User() { Id = "2", FirstName = "user2f", Surname = "user2s", Email = "user2@bu.com" };
            var user3 = new User() { Id = "3", FirstName = "user3f", Surname = "user3s", Email = "user3@bu.com" };

            db.AddRange(user1, user2, user3);
            await db.SaveChangesAsync();

            var adminUserService = new AdminUserService(db);

            // Act
            var result = await adminUserService.AllAsync("user2");
            
            // Assert
            Assert.True(result.Count() == 1);
        }
    }
}
