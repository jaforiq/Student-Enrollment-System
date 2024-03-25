using Microsoft.EntityFrameworkCore;
using Student_Enrollment_System.Data;
using Student_Enrollment_System.Mappings;
using Student_Enrollment_System.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StudentEnrollmentDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("StudentConnectionString")));

builder.Services.AddScoped<IStudentRepository,SQLStudentRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
