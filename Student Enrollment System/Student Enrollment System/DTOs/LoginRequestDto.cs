using System.ComponentModel.DataAnnotations;

namespace Student_Enrollment_System.DTOs;

public class LoginRequestDto
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Username { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
