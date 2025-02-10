using eAppointmentServer.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace eAppointmentService.API
{
    public static class Helper
    {
        public static async Task CreateUser(WebApplication app)
        {
            using (var scoped = app.Services.CreateScope())
            {
                var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                if (!userManager.Users.Any())
                {
                    await userManager.CreateAsync(new()
                    {
                        FirstName = "Emre",
                        LastName = "ÖZGÖZ",
                        Email = "admin@admin.com",
                        UserName = "admin"
                    }, "1");
                }
            }

        }
    }
}
