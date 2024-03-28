using Microsoft.AspNetCore.Identity;

namespace Student_Enrollment_System.Repository;

public interface ITokenRepository
{
    string CreateJWTtoken(IdentityUser user, List<string> roles);
}
