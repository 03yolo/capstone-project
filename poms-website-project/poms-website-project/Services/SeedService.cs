using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using poms_website_project;
using poms_website_project.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AdminSide_withLogin.Services
{
    public class SeedService
    {
        public static async Task SeedDatabase(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<PdfmnhsDbContext>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<SeedService>>();

            try
            {
                logger.LogInformation("Ensuring the database is created.");
                await context.Database.EnsureCreatedAsync();

                logger.LogInformation("Seeding Roles.");
                var roles = new string[] { "Admin", "User", "Faculty", "Student", "Parent" };

                foreach (var roleName in roles)
                {
                    if (!context.Roles.Any(r => r.RoleName == roleName))
                    {
                        context.Roles.Add(new Role { RoleName = roleName });
                    }
                }
                await context.SaveChangesAsync();

                // ✅ Seed Admin User
                logger.LogInformation("Seeding admin user.");
                var adminEmail = "pdfmnhs@gmail.com";

                if (!context.Users.Any(u => u.Email == adminEmail))
                {
                    var adminRoleId = context.Roles.First(r => r.RoleName == "Admin").RoleId;

                    var adminUser = new User
                    {
                        FullName = "PDFMNHS Admin",
                        Email = adminEmail,
                        PasswordHash = "Admin@123", // ⚠ Plain text for now
                        RoleId = adminRoleId,
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    };

                    context.Users.Add(adminUser);
                    await context.SaveChangesAsync();

                    logger.LogInformation("Admin user created successfully.");
                }

                // ✅ Seed Faculty Users
                logger.LogInformation("Seeding faculty users.");
                var facultyRoleId = context.Roles.First(r => r.RoleName == "Faculty").RoleId;

                var facultyUsers = new[]
                {
                    new { FullName = "Faculty Member 1", Email = "faculty1@pdfmnhs.com" },
                    new { FullName = "Faculty Member 2", Email = "faculty2@pdfmnhs.com" }
                };

                foreach (var f in facultyUsers)
                {
                    if (!context.Users.Any(u => u.Email == f.Email))
                    {
                        context.Users.Add(new User
                        {
                            FullName = f.FullName,
                            Email = f.Email,
                            PasswordHash = "Faculty@123", // ⚠ Plain text for now
                            RoleId = facultyRoleId,
                            IsActive = true,
                            CreatedAt = DateTime.UtcNow
                        });
                    }
                }

                // ✅ Seed Parent Users
                logger.LogInformation("Seeding faculty users.");
                var parentRoleId = context.Roles.First(r => r.RoleName == "Parent").RoleId;

                var parentUsers = new[]
                {
                    new { FullName = "Parent Member 1", Email = "parent1@pdfmnhs.com" },
                    new { FullName = "Parent Member 2", Email = "parent2@pdfmnhs.com" }
                };

                foreach (var p in parentUsers)
                {
                    if (!context.Users.Any(u => u.Email == p.Email))
                    {
                        context.Users.Add(new User
                        {
                            FullName = p.FullName,
                            Email = p.Email,
                            PasswordHash = "Parent@123", // ⚠ Plain text for now
                            RoleId = parentRoleId,
                            IsActive = true,
                            CreatedAt = DateTime.UtcNow
                        });
                    }
                }

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while seeding the database.");
            }
        }
    }
}
