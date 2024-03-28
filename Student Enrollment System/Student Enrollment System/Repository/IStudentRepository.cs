using Microsoft.AspNetCore.Mvc;
using Student_Enrollment_System.DTOs;
using Student_Enrollment_System.Model;
using System.Runtime.InteropServices;

namespace Student_Enrollment_System.Repository;

public interface IStudentRepository
{
    Task<Student> CreateAsync(Student student);
    Task<List<Student>> GetAllAsync();
    Task<Student?> GetByIdAsync(Guid id);
    Task<Student> UpdateAsync(Guid id, Student student);
    Task<Student> DeleteAsync([FromQuery] Guid id);
}
