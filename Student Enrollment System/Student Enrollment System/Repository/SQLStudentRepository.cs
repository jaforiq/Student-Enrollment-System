using Student_Enrollment_System.Data;
using Student_Enrollment_System.Model;

namespace Student_Enrollment_System.Repository;

public class SQLStudentRepository : IStudentRepository
{
    private readonly StudentEnrollmentDbContext _studentEnrollmentDbContext;

    public SQLStudentRepository(StudentEnrollmentDbContext studentEnrollmentDbContext)
    {
        _studentEnrollmentDbContext = studentEnrollmentDbContext;
    }
    public async Task<Student> CreateAsync(Student student)
    {
         _studentEnrollmentDbContext.Students.Add(student);
        await _studentEnrollmentDbContext.SaveChangesAsync();
        return student;
           
    }
}
