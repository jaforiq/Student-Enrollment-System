using Student_Enrollment_System.Validation;
using System.ComponentModel.DataAnnotations;

namespace Student_Enrollment_System.DTOs;

public class AddStudentDto
{
    [StringCheck(ErrorMessage = "Input must be a string.")]
    public string Name { get; set; }
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; }
    [Required]
    [MinLength(11,ErrorMessage = "11 digit mobile number is must.")]
    [MaxLength(11,ErrorMessage = "11 digit mobile number is must.")]
    public string Phone { get; set; }
    [Required]
    [StringCheck(ErrorMessage = "Input must be a string.")]
    public string DateOfBirth { get; set; }
    [Required]
    [StringCheck(ErrorMessage = "Input must be a string.")]
    public string Gender { get; set; }
    [Required]
    [StringCheck(ErrorMessage = "Input must be a string.")]
    public string Address { get; set; }
}
