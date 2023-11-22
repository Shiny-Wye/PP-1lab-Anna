using PP_1lab_Anna.Interfaces.CoursesInterfaces;
using PP_1lab_Anna.Interfaces.StudentsInterfaces;

namespace PP_1lab_Anna.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ICoursesService, CourseService>();

            return services;
        }
    }
}