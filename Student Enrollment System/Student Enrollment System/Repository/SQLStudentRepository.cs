using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Enrollment_System.Data;
using Student_Enrollment_System.DTOs;
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

    public async Task<List<Student>> GetAllAsync()
    {
        return await _studentEnrollmentDbContext.Students.ToListAsync();
    }

    public async Task<Student?> GetByIdAsync(Guid id)
    {
        return await _studentEnrollmentDbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

    }

    public async Task<Student> UpdateAsync(Guid id, Student student)
    {
        var existingStudent = await _studentEnrollmentDbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
        if (existingStudent == null)
        {
            return null;
        }

        existingStudent.Name = student.Name;
        existingStudent.Email = student.Email;
        existingStudent.Phone = student.Phone;
        existingStudent.DateOfBirth = student.DateOfBirth;
        existingStudent.Address = student.Address;
        existingStudent.Gender = student.Gender;

        await _studentEnrollmentDbContext.SaveChangesAsync();
        return existingStudent;
    }

    public async Task<Student> DeleteAsync([FromQuery] Guid id)
    {
        var existingStudent = await _studentEnrollmentDbContext.Students.FirstOrDefaultAsync(x =>x.Id == id); 
        if(existingStudent == null)
        {
            return null;
        }
        _studentEnrollmentDbContext.Students.Remove(existingStudent);
        await _studentEnrollmentDbContext.SaveChangesAsync();
        return existingStudent;
    }
}
