using PP_1lab_Anna.Database;
using PP_1lab_Anna.Models;
using Microsoft.EntityFrameworkCore;
using PP_1lab_Anna.Filters;

namespace PP_1lab_Anna.Interfaces.CoursesInterfaces
{
    public interface ICoursesService
    {
        public Task<Course[]> GetCoursesByGroupAsync(CourseFilter filter, CancellationToken cancellationToken);
    }

    public class CourseService : ICoursesService
    {
        private readonly StudentDbContext _dbContext;
        public CourseService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Course[]> GetCoursesByGroupAsync(CourseFilter filter, CancellationToken cancellationToken = default)
        {
            var courses = _dbContext.Set<Course>().Where(w => w.Group.GroupName == filter.GroupName).ToArrayAsync(cancellationToken);

            return courses;
        }
    }
}