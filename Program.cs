using Dapper;
using Exam9.DataContext;
using Exam9.Extension;
using Exam9.Middleware;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddService();
builder.Services.AddDbContext<ApplicationContext>(x =>
    x.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.UseMiddleware<EmployeeMiddleware>();

app.Run();