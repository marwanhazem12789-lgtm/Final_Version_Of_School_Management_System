using Microsoft.EntityFrameworkCore;

namespace Final_Version_Of_School_Management_System.Models
{
    public class Context : DbContext
    {   
        public Context(DbContextOptions<Context> opt):base(opt) { }


        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<AppUser> appUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>()
               .HasOne(t => t.Department)
               .WithMany(d => d.Teachers)
               .HasForeignKey(t => t.DepartmentId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Subject>()
                .HasOne(s => s.Teacher)
                .WithMany(t => t.Subjects)
                .HasForeignKey(s => s.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.ClassRoom)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.ClassroomId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Subject)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Teacher>()
                .HasIndex(t => t.Email)
                .IsUnique();

            modelBuilder.Entity<Student>()
                .HasIndex(s => s.Email)
                .IsUnique();

            modelBuilder.Entity<Enrollment>()
                .HasIndex(e => new { e.StudentId, e.SubjectId })
                .IsUnique();
            modelBuilder.Entity<Teacher>()
                .Property(h => h.Price)
                .HasPrecision(12, 2);



            modelBuilder.Entity<Department>().HasData(
           new Department { Id = 1, Name = "Computer Science", Description = "CS Dept" },
           new Department { Id = 2, Name = "Mathematics", Description = "Math Dept" }
       );

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    Id = 1,
                    FirstName = "Ahmed",
                    LastName = "Ali",
                    Email = "ahmed.ali@school.com",
                    PhoneNumber = "01012345678",
                    Price = 1254,
                    DepartmentId = 1
                },
                new Teacher
                {
                    Id = 2,
                    FirstName = "Sara",
                    LastName = "Hassan",
                    Email = "sara.hassan@school.com",
                    PhoneNumber = "01123456789",
                    Price = 1258,
                    DepartmentId = 2
                }
            );

            modelBuilder.Entity<ClassRoom>().HasData(
                new ClassRoom { Id = 1, Name = "Class A1", Capacity = 30, GradeLevel = 10 },
                new ClassRoom { Id = 2, Name = "Class B2", Capacity = 25, GradeLevel = 11 }
            );

            modelBuilder.Entity<Subject>().HasData(
                new Subject { Id = 1, Name = "C# Programming", Description = "OOP Basics", MaxGrade = 100, TeacherId = 1 },
                new Subject { Id = 2, Name = "Calculus I", Description = "Calculus", MaxGrade = 100, TeacherId = 2 }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FirstName = "Omar",
                    LastName = "Khaled",
                    Email = "omar@student.com",
                    PhoneNumber = "01234567890",
                    DateOfBirth = new DateTime(2008, 5, 14),
                    ClassroomId = 1
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Mona",
                    LastName = "Mahmoud",
                    Email = "mona@student.com",
                    PhoneNumber = "01543216789",
                    DateOfBirth = new DateTime(2007, 9, 20),
                    ClassroomId = 2
                }
            );

            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { Id = 1, StudentId = 1, SubjectId = 1, Grade = 85, EnrollmentDate = new DateTime(2025, 9, 1) },
                new Enrollment { Id = 2, StudentId = 2, SubjectId = 2, Grade = 92, EnrollmentDate = new DateTime(2025, 9, 1) }
            );
        }

    }
}
