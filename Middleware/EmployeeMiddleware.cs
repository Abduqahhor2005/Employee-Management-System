using System.Text.Json;
using Dapper;
using Npgsql;

namespace Exam9.Middleware;

public class EmployeeMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/employees"))
        {
            using (NpgsqlConnection con = new("Host=localhost;Database=crud_db;Username=postgres;Port=4321;Password=salom;"))
            {
                await con.OpenAsync();
                var employees = await con.QueryAsync("select * from employees where extract(year from \"dateOfBirth\") < 2007");

                var jsonResult = JsonSerializer.Serialize(employees);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(jsonResult);
                return; 
            }
        }
        await next(context);
    }
}