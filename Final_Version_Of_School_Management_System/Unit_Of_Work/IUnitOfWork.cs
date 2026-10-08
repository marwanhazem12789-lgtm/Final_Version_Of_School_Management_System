using Final_Version_Of_School_Management_System.GenaricRepos;
using Final_Version_Of_School_Management_System.Models;

namespace Final_Version_Of_School_Management_System.Unit_Of_Work
{
    public interface IUnitOfWork
    {
        IGenaricRepo<Student> Student { get; }
        IGenaricRepo<Department> Department { get; }
        IGenaricRepo<Teacher> Teacher { get; }
        IGenaricRepo<Subject> Subject { get; }
        IGenaricRepo<ClassRoom> ClassRoom { get; }
        IGenaricRepo<Enrollment> Enrollment { get; }

        int Save();
       
    }
}
