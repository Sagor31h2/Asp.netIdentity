using IdentityService.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Extensions
{
    public static class ServiceExtenstions
    {
        public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer(configuration.GetConnectionString("Default")));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
            services.Configure<IdentityOptions>(op =>
            {
                op.Password.RequiredLength = 5;
                op.Password.RequireLowercase = true;
                op.Lockout.MaxFailedAccessAttempts = 2;
                op.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
           //     op.SignIn.RequireConfirmedAccount = true;
            });
        }
    }
}
