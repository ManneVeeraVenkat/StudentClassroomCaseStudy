using Microsoft.EntityFrameworkCore;
using StudentClassroomCaseStudy.Data;
using StudentClassroomCaseStudy.Interface;
using StudentClassroomCaseStudy.Repository;
using SubjectClassroomCaseStudy.Interface;
using System.Text.Json.Serialization;
using TeacherClassroomCaseStudy.Interface;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers().AddNewtonsoftJson(options =>
//    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
//);
//builder.Services.AddControllers()
//    .AddJsonOptions(options =>
//    {
//        options.JsonSerializerOptions.PropertyNamingPolicy = null; // Use the default naming policy
//        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
//    });



// Add services to the container.

builder.Services.AddCors(options => options.AddPolicy("MyPolicy", builder =>
{

    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();

}));
builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IClassroomRepository, ClassroomRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<IAllocateSubjectRepository, AllocateSubjectRepository>();
builder.Services.AddScoped<IAllocateClassroomRepository, AllocateClassroomRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
