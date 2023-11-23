using PP_1lab_Anna.Database;
using PP_1lab_Anna.Models;
using Microsoft.EntityFrameworkCore;
using PP_1lab_Anna.Filters.StudentGroupFilter;
using PP_1lab_Anna.Filters.StudentFIOFilter;
using PP_1lab_Anna.Interfaces.StudentsInterfaces;

namespace PP_1lab_Anna.Interfaces.StudentsInterfaces
{
    public interface IStudentService
    {
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken);
        public Task<Student[]> GetStudentsByFioAsync(StudentFIOFilter filter, CancellationToken cancellationToken);
    }
}

    public class StudentService : IStudentService
{
        private readonly StudentDbContext _dbContext;
        public StudentService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => w.Group.GroupName == filter.GroupName).ToArrayAsync(cancellationToken);

            return students;
        }

    public Task<Student[]> GetStudentsByFioAsync(StudentFIOFilter filter, CancellationToken cancellationToken = default)
    {
        var students = _dbContext.Set<Student>().Where(w => (w.FirstName == filter.FIO) || (w.MiddleName == filter.FIO) || (w.LastName == filter.FIO)).ToArrayAsync(cancellationToken);

        return students;
    }

}