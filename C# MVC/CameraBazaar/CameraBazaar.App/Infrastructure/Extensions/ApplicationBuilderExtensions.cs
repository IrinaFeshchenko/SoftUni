namespace CameraBazaar.App.Infrastructure.Extensions
{
    using CameraBazaar.Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;
    using CameraBazaar.Data.Models;
    using Microsoft.AspNetCore.Identity;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<CameraBazaarDbContext>().Database.Migrate();

                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();

                Task
                    .Run(async () =>
                   {
                       var adminName = GlobalConstants.AdministratorRole;

                       var roleExists = await roleManager.RoleExistsAsync(adminName);

                       if (!roleExists)
                       {
                           await roleManager.CreateAsync(new IdentityRole
                           {
                               Name = adminName
                           });
                       }

                       var adminEmail = "admin@mysite.com";
                       var adminUser = await userManager.FindByNameAsync(adminEmail);

                       if (adminUser == null)
                       {
                           adminUser = new User
                           {
                               Email = adminEmail,
                               UserName = adminEmail
                           };

                           await userManager.CreateAsync(adminUser, "admin123");

                           await userManager.AddToRoleAsync(adminUser, adminName);
                       }
                   })
                    .Wait();
            }

            return app;
        }
    }
}
