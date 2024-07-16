using MachineTest.Interfaces;
using MachineTest.Repository;
using MachineTest.Services;
using MachineTest.Models;
using Microsoft.EntityFrameworkCore;

namespace MachineTest.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services,IConfiguration config) 
        {
            services.AddDbContext<NewContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
          
            services.AddScoped<IEmployeeServices, EmployeeServices>();
            services.AddScoped<ICourseServices, CourseServices>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IAttendenceRepository, AttendenceRepository>();
            services.AddScoped<IAttendenceServices, AttendenceServices>();

            return services;
        }
    }
}
