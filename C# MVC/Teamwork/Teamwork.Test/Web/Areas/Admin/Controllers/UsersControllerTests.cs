using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Teamwork.Web.Areas.Admin.Controllers;
using Xunit;
using static Teamwork.Common.GlobalConstants;

namespace Teamwork.Test.Web.Areas.Admin.Controllers
{
    public class UsersControllerTests
    {
        private readonly TestHelpers testHelpers;
        public UsersControllerTests()
        {
            TestInit.InitializeMapper();
            testHelpers = new TestHelpers();
        }

        [Fact]
        public void UsersAdministrationAccessibleForAdministratorsOnly()
        {
            // Arrange
            var classType = typeof(BaseAdminController);

            // Act
            var attributes = classType.GetCustomAttributes(true);
            var attr = attributes.Where(a => a.GetType() == typeof(AuthorizeAttribute)).FirstOrDefault();
            var roles = (attr as AuthorizeAttribute).Roles.Split(",");

            // Assert
            Assert.Contains(attributes, a => a.GetType() == typeof(AuthorizeAttribute));
            Assert.Contains(roles, r => r == AdministratorRole);
            Assert.DoesNotContain(roles, r => r != AdministratorRole);
        }
    }
}
