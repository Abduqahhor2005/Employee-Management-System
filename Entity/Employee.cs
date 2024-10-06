using System.ComponentModel.DataAnnotations;

namespace Exam9.Entity;
public class Employee
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    [MinLength(10)]
    public string Phone { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public DateTime HireDate { get; set; }
    public string Position { get; set; } = null!;
    public double Salary { get; set; }
    public string DepartmentName { get; set; } = null!;
    public string ManagerName { get; set; } = null!;
    public bool IsActive { get; set; }
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}