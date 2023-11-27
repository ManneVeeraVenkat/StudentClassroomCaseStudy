using Microsoft.EntityFrameworkCore;
using StudentClassroomCaseStudy.Model;

namespace StudentClassroomCaseStudy.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects{ get; set; }
        public DbSet<AllocateClassroom> AllocateClassrooms { get; set; }
        public DbSet<AllocateSubject> AllocateSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // AllocateSubject (Many-to-Many) Subject and Teacher
            modelBuilder.Entity<AllocateSubject>()
                .HasKey(asub => new { asub.SubjectId, asub.TeacherId });
            modelBuilder.Entity<AllocateSubject>()
                .HasOne(s=>s.Subject).WithMany(As => As.AllocateSubjects).HasForeignKey(s=>s.SubjectId);

            modelBuilder.Entity<AllocateSubject>()
               .HasOne(T => T.Teacher).WithMany(As => As.AllocateSubjects).HasForeignKey(s => s.TeacherId);

            // AllocateClassroom (Many-to-Many) Teacher and Classroom
            modelBuilder.Entity<AllocateClassroom>()
                .HasKey(ac => new { ac.TeacherId, ac.ClassroomId });
            modelBuilder.Entity<AllocateClassroom>()
              .HasOne(c=>c.Classroom).WithMany(Ac => Ac.AllocateClassrooms).HasForeignKey(c=>c.ClassroomId);

            modelBuilder.Entity<AllocateClassroom>()
               .HasOne(T => T.Teacher).WithMany(As => As.AllocateClassrooms).HasForeignKey(s => s.TeacherId);

            modelBuilder.Entity<Student>().HasData(
               new Student { StudentId = 1, FirstName = "John", LastName = "Doe", ClassroomId = 1  },
               new Student { StudentId = 2, FirstName = "Jane", LastName = "Smith", ClassroomId = 2  }
           // Add more students here
           );

            modelBuilder.Entity<Classroom>().HasData(
                new Classroom { ClassroomId = 1, ClassroomName = "Class A",  },
                new Classroom { ClassroomId = 2, ClassroomName = "Class B",  }
                // Add more classrooms here
            );

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { TeacherId = 1, FirstName = "Teacher1", LastName = "Smith",  },
                new Teacher { TeacherId = 2, FirstName = "Teacher2", LastName = "Doe",  }
                // Add more teachers here
            );

            modelBuilder.Entity<Subject>().HasData(
                new Subject { SubjectId = 1, SubjectName = "Math",  },
                new Subject { SubjectId = 2, SubjectName = "Science",  }
                // Add more subjects here
            );

            // Mock data for AllocateSubject
            modelBuilder.Entity<AllocateSubject>().HasData(
                new AllocateSubject { AllocateSubjectId = 1, TeacherId = 1, SubjectId = 1 },
                new AllocateSubject { AllocateSubjectId = 2, TeacherId = 1, SubjectId = 2 },
                new AllocateSubject { AllocateSubjectId = 3, TeacherId = 2, SubjectId = 2 }
                // Add more allocations here
            );

            // Mock data for AllocateClassroom
            modelBuilder.Entity<AllocateClassroom>().HasData(
                new AllocateClassroom { AllocateClassroomId = 1, TeacherId = 1, ClassroomId = 1 },
                new AllocateClassroom { AllocateClassroomId = 2, TeacherId = 2, ClassroomId = 2 }
                // Add more allocations here
            );

            // Student and Classroom (One-to-Many)
            //modelBuilder.Entity<Student>()
            //    .HasOne(s => s.Classroom)
            //    .WithMany(c => c.Students);


            //// Classroom and AllocateClassroom (One-to-Many)
            //modelBuilder.Entity<Classroom>()
            //    .HasMany(c => c.AllocateClassrooms)
            //    .WithOne(ac => ac.Classroom)
            //    .HasForeignKey(ac => ac.ClassroomId);

            //// Teacher and AllocateSubject (One-to-Many)
            //modelBuilder.Entity<Teacher>()
            //    .HasMany(t => t.AllocateSubjects)
            //    .WithOne(asub => asub.Teacher)
            //    .HasForeignKey(asub => asub.TeacherId);

            // Teacher and AllocateClassroom (One-to-Many)
            //modelBuilder.Entity<Teacher>()
            //    .HasMany(t => t.AllocateClassrooms)
            //    .WithOne(ac => ac.Teacher)
            //    .HasForeignKey(ac => ac.TeacherId);




            // Subject and AllocateSubject (One-to-Many)
            //modelBuilder.Entity<Subject>()
            //    .HasMany(sub => sub.AllocateSubjects)
            //    .WithOne(asub => asub.Subject)
            //    .HasForeignKey(asub => asub.SubjectId);


        }

    }
}
