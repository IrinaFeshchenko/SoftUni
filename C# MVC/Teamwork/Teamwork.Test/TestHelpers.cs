using Microsoft.AspNetCore.Identity;
using Moq;
using Teamwork.Data.Models;

namespace Teamwork.Test
{
    public class TestHelpers
    {
        public UserManager<User> GetUserManagerMock()
        {
            return new Mock<UserManager<User>>(Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null).Object;
        }

        public RoleManager<IdentityRole> GetRoleManagerMock()
        {
            return new Mock<RoleManager<IdentityRole>>(Mock.Of<IRoleStore<IdentityRole>>(), null, null, null, null).Object;
        }
    }
}
