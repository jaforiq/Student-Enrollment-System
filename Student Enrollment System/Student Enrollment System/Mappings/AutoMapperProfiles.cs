using AutoMapper;
using Student_Enrollment_System.DTOs;
using Student_Enrollment_System.Model;

namespace Student_Enrollment_System.Mappings;

public class AutoMapperProfiles: Profile    
{
    public AutoMapperProfiles()
    {
        CreateMap<AddStudentDto,Student>().ReverseMap();
        CreateMap<Student,StudentDto>().ReverseMap(); 
        CreateMap<UpdateStudentDto,Student>().ReverseMap();
    }
    
}
