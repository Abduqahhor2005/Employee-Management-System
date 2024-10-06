using Exam9.Entity;

namespace Exam9.Service;

public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task<IEnumerable<Employee>> GetAllEmployeesByActive(bool isActive);
    Task<IEnumerable<Employee>> GetAllEmployeesByDepartmentName(string departmentName);
    Task<IEnumerable<Employee>> GetAllEmployeesBySalary();
    Task<IEnumerable<Employee>> GetAllEmployeesByBirthdays(DateTime startDate, DateTime endDate);
    Task<Employee?> GetEmployeeByIdAsync(Guid id);
    Task<bool> CreateAsync(Employee employee);
    Task<bool> UpdateAsync(Employee employee);
    Task<bool> DeleteAsync(Guid id);
}