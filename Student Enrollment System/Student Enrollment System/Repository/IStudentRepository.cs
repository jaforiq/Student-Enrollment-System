using Student_Enrollment_System.Model;
using System.Runtime.InteropServices;

namespace Student_Enrollment_System.Repository;

public interface IStudentRepository
{
   Task<Student> CreateAsync(Student student);
}
