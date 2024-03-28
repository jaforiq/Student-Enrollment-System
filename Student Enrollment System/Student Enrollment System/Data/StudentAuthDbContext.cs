using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Student_Enrollment_System.Data;

public class StudentAuthDbContext : IdentityDbContext
{
    public StudentAuthDbContext(DbContextOptions<StudentAuthDbContext> options) :base(options)
    {        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var readerRoleId = "9a3a94af-6e48-428d-bb3f-7f7fa9058267";
        var writerRoleId = "5e9f0463-02c2-48c4-b9fb-65cd8ceabb67";
        var roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Id = readerRoleId,
                ConcurrencyStamp = readerRoleId,
                Name = "Reader",
                NormalizedName = "Reader".ToUpper()
            },
            new IdentityRole
            {
                Id = writerRoleId,
                ConcurrencyStamp = writerRoleId,
                Name = "Writer",
                NormalizedName = "Writer".ToUpper()
            }
        };

        builder.Entity<IdentityRole>().HasData(roles); 
    }
}
