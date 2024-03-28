using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Student_Enrollment_System.DTOs;
using Student_Enrollment_System.Model;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Writer")]
    public async Task<IActionResult> Create([FromBody] AddStudentDto addStudentDto)
    {
        var studentDomainModel = _mapper.Map<Student>(addStudentDto);
        
        await _studentRepository.CreateAsync(studentDomainModel);
        return Ok(_mapper.Map<StudentDto>(studentDomainModel));
    }

    [HttpGet]
    [Authorize(Roles = "Reader,Writer")]
    public async Task<IActionResult>GetAll()
    {
        var studentDomainModel = await _studentRepository.GetAllAsync();
        return Ok(_mapper.Map<List<StudentDto>>(studentDomainModel));
    }

    [HttpGet]
    [Route("{id:Guid}")]
    [Authorize(Roles = "Reader,Writer")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var studentDomainModel = await _studentRepository.GetByIdAsync(id);
        if(studentDomainModel == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<StudentDto>(studentDomainModel));
    }

    [HttpPut]
    [Route("{id:Guid}")]
    [Authorize(Roles = "Writer")]
    public async Task<IActionResult> Update([FromRoute] Guid id, UpdateStudentDto updateStudentDto)
    {
        var studentDomainModel = _mapper.Map<Student>(updateStudentDto);
        studentDomainModel = await _studentRepository.UpdateAsync(id, studentDomainModel);
        if(studentDomainModel == null)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<StudentDto>(studentDomainModel));
    }

    [HttpDelete]
    [Route("{id:Guid}")]
    [Authorize(Roles = "Writer")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var deletedStudent = await _studentRepository.DeleteAsync(id);
        if(deletedStudent == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<StudentDto>(deletedStudent));
    }
}
