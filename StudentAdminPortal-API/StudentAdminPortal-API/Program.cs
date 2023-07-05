using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentAdminPortal_API.Data;
using StudentAdminPortal_API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Binding.
//dependency injection of DBContext.
builder.Services.AddDbContext<StudentAdminContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentAdminPortalConn")));

//when Istudentrepo is accessed, object of which class needs to be created shud be specified here.
//here when IStudentRepository is accessed in StudentController, I need to create object of StudentImplementRepository.
builder.Services.AddScoped<IStudentRepository, StudentImplementRepository>();

//Here specifying which auto mapping needs to be considered.
//Here "typeof(Program).Assembly" will point to the parent of Program file which includes all the files 
//and all the Profiles present in this path will be considered for auto mapping.
builder.Services.AddAutoMapper(typeof(Program).Assembly);

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
