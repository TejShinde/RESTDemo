using Microsoft .EntityFrameworkCore;
using RESTDemo .Data;
using RESTDemo .Repositories;
using RESTDemo .Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var conn = builder .Configuration .GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer(conn));

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService , BookService>();

builder .Services .AddScoped<IStudentRepository , StudentRepository>();
builder .Services .AddScoped<IStudentService , StudentService>();

// Register User services
builder .Services .AddScoped<IUserRepository , UserRepository>();
builder .Services .AddScoped<IUserService , UserService>();

// Add CORS policy
builder .Services .AddCors(options => options .AddDefaultPolicy(
                builder => builder .WithOrigins("http://localhost:4200") .AllowAnyMethod() .AllowAnyHeader()
            ));


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();
app .UseCors();
app.MapControllers();

app.Run();
