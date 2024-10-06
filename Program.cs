using Dapper;
using Exam9.DataContext;
using Exam9.Extension;
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
app.MapGet("/employees", async ()=>
{
    using (NpgsqlConnection con = new("Host=localhost;Database=crud_db;Username=postgres;Port=4321;Password=salom;"))
    {
        con.Open();
        return await con.QueryAsync("select * from employees where extract(year from \"dateOfBirth\")<2007");
    }
});

app.Run();