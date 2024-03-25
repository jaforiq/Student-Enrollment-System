using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Enrollment_System.DTOs;
using Student_Enrollment_System.Model;
using Student_Enrollment_System.Repository;

namespace Student_Enrollment_System.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentEnrollmentController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IStudentRepository _studentRepository;

    public StudentEnrollmentController(IMapper mapper, IStudentRepository studentRepository)
    {
        _mapper = mapper;
        _studentRepository = studentRepository;
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddStudentDto addStudentDto)
    {
        var studentDomainModel = _mapper.Map<Student>(addStudentDto);
        
        await _studentRepository.CreateAsync(studentDomainModel);
        return Ok(_mapper.Map<StudentDto>(studentDomainModel));
    }
}
