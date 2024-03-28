using Microsoft.EntityFrameworkCore;
using Student_Enrollment_System.Model;

namespace Student_Enrollment_System.Data;

public class StudentEnrollmentDbContext: DbContext
{
    public StudentEnrollmentDbContext(DbContextOptions<StudentEnrollmentDbContext> dbContextOptions) : base(dbContextOptions)
    {
        
    }

    public DbSet<Student> Students { get; set; }
}
