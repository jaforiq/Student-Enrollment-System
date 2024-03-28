using System.ComponentModel.DataAnnotations;

namespace Student_Enrollment_System.Validation;

public class StringCheckAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value == null)
        {
            return false;
        }

        return value is string;
    }
}
