using Dapper;
using Exam9.DataContext;
using Exam9.Entity;
using Npgsql;

namespace Exam9.Service;

public class EmployeeService(ApplicationContext applicationContext) : IEmployeeService
{
    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.Connection))
            {
                con.Open();
                return await con.QueryAsync<Employee>(SqlCommands.GetAll);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public async Task<IEnumerable<Employee>> GetAllEmployeesByActive(bool isActive)
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.Connection))
            {
                con.Open();
                return await con.QueryAsync<Employee>(SqlCommands.GetByActive,new{IsActive=isActive});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public async Task<IEnumerable<Employee>> GetAllEmployeesByDepartmentName(string departmentName)
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.Connection))
            {
                con.Open();
                return await con.QueryAsync<Employee>(SqlCommands.GetByDepartmentName,new{DepartmentName=departmentName});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public async Task<IEnumerable<Employee>> GetAllEmployeesBySalary()
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.Connection))
            {
                con.Open();
                return await con.QueryAsync<Employee>(SqlCommands.GetBySalary);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public async Task<IEnumerable<Employee>> GetAllEmployeesByBirthdays(DateTime startDate, DateTime endDate)
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.Connection))
            {
                con.Open();
                return await con.QueryAsync<Employee>(SqlCommands.GetByBirthdays,new{StartDate=startDate,EndDate=endDate});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public async Task<Employee?> GetEmployeeByIdAsync(Guid id)
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.Connection))
            {
                con.Open();
                return await con.QueryFirstOrDefaultAsync<Employee>(SqlCommands.GetById,new{Id=id});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public async Task<bool> CreateAsync(Employee employee)
    {
        try
        {
            if (employee == null) return false;
            applicationContext.Employees.Add(employee);
            return await applicationContext.SaveChangesAsync() > 0;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public async Task<bool> UpdateAsync(Employee employee)
    {
        try
        {
            Employee? employee1 = await applicationContext.Employees.FindAsync(employee.Id);
            if (employee1 == null) return false;
            employee1.FirstName = employee.FirstName;
            employee1.LastName = employee.LastName;
            employee1.Email = employee.Email;
            employee1.Phone = employee.Phone;
            employee1.DateOfBirth = employee.DateOfBirth;
            employee1.HireDate = employee.HireDate;
            employee1.Position = employee.Position;
            employee1.Salary = employee.Salary;
            employee1.DepartmentName = employee.DepartmentName;
            employee1.ManagerName = employee.ManagerName;
            employee1.IsActive = employee.IsActive;
            employee1.Address = employee.Address;
            employee1.City = employee.City;
            employee1.Country = employee.Country;
            employee1.CreatedAt = employee.CreatedAt;
            employee1.UpdatedAt = employee.UpdatedAt;
            return await applicationContext.SaveChangesAsync() > 0;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public async Task<bool> DeleteAsync(Guid id)
    {
        try
        {
            Employee? employee = await applicationContext.Employees.FindAsync(id);
            if (employee == null) return false;
            applicationContext.Remove(employee);
            return await applicationContext.SaveChangesAsync() > 0;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}



file class SqlCommands()
{
    public const string Connection = @"Host=localhost;Database=crud_db;Username=postgres;Port=4321;Password=salom;";
    public const string GetAll = @"select * from employees";
    public const string GetById = @"select * from employees where id=@id";
    public const string GetByActive = @"select * from employees where ""isActive""=@isActive";
    public const string GetByDepartmentName = @"select * from employees where ""departmentName""=@departmentName";
    public const string GetBySalary = @"select * from employees order by salary desc";
    public const string GetByBirthdays = @"select * from employees where ""dateOfBirth"" between @startDate and @endDate";
}