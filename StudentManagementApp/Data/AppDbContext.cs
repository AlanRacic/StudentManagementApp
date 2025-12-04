using StudentManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentID = 1,
                    StudentName = "Alex Johnson",
                    DateOfBirth = new DateTime(2006, 2, 15),
                    Height = 1.76m,
                    Weight = 68.5f
                },
                new Student
                {
                    StudentID = 2,
                    StudentName = "Emily Carter",
                    DateOfBirth = new DateTime(2007, 10, 2),
                    Height = 1.65m,
                    Weight = 54.3f
                },
                new Student
                {
                    StudentID = 3,
                    StudentName = "Liam Miller",
                    DateOfBirth = new DateTime(2006, 6, 21),
                    Height = 1.80m,
                    Weight = 74.2f
                },
                new Student
                {
                    StudentID = 4,
                    StudentName = "Sophia Brown",
                    DateOfBirth = new DateTime(2007, 3, 11),
                    Height = 1.70m,
                    Weight = 59.8f
                }
            );

            modelBuilder.Entity<Grade>().HasData(
                // Alex Johnson (ID = 1)
                new Grade { GradeId = 1, GradeName = "A", Section = "Mathematics", StudentId = 1 },
                new Grade { GradeId = 2, GradeName = "B", Section = "Physics", StudentId = 1 },
                new Grade { GradeId = 3, GradeName = "A", Section = "Computer Science", StudentId = 1 },

                // Emily Carter (ID = 2)
                new Grade { GradeId = 4, GradeName = "B", Section = "Mathematics", StudentId = 2 },
                new Grade { GradeId = 5, GradeName = "A", Section = "English Language", StudentId = 2 },
                new Grade { GradeId = 6, GradeName = "C", Section = "Biology", StudentId = 2 },

                // Liam Miller (ID = 3)
                new Grade { GradeId = 7, GradeName = "A", Section = "Mathematics", StudentId = 3 },
                new Grade { GradeId = 8, GradeName = "B", Section = "Chemistry", StudentId = 3 },
                new Grade { GradeId = 9, GradeName = "A", Section = "Physics", StudentId = 3 },

                // Sophia Brown (ID = 4)
                new Grade { GradeId = 10, GradeName = "B", Section = "History", StudentId = 4 },
                new Grade { GradeId = 11, GradeName = "A", Section = "English Language", StudentId = 4 },
                new Grade { GradeId = 12, GradeName = "B", Section = "Physical Education", StudentId = 4 }
            );
        }
    }
}


