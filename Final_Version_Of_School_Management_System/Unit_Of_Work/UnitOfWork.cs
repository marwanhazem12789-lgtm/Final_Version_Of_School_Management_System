using Final_Version_Of_School_Management_System.GenaricRepos;
using Final_Version_Of_School_Management_System.Models;

namespace Final_Version_Of_School_Management_System.Unit_Of_Work
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
   
        public IGenaricRepo<Student> Student { get; }

        public IGenaricRepo<Department> Department { get; }

        public IGenaricRepo<Teacher> Teacher { get; }

        public IGenaricRepo<Subject> Subject { get; }

        public IGenaricRepo<ClassRoom> ClassRoom { get; }

        public IGenaricRepo<Enrollment> Enrollment { get; }

        public UnitOfWork(Context c , IGenaricRepo<Student> s , IGenaricRepo<Subject> sb , IGenaricRepo<Enrollment> e , IGenaricRepo<ClassRoom> cr , IGenaricRepo<Teacher> t , IGenaricRepo<Department>d)
        {
            _context = c;
            Student = s;
            Subject = sb;
            Enrollment = e;
            ClassRoom = cr;
            Teacher = t;
            Department = d;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
