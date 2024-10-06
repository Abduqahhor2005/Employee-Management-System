using Exam9.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam9.DataConfig;

public class UserConfig:IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("employees");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired().HasColumnName("id").HasColumnType("uuid");
        builder.Property(x => x.FirstName).IsRequired().HasColumnName("firstName").HasColumnType("varchar(100)");
        builder.Property(x => x.LastName).IsRequired().HasColumnName("lastName").HasColumnType("varchar(100)");
        builder.HasAlternateKey(x => x.Email);
        builder.Property(x => x.Email).IsRequired().HasColumnName("email").HasColumnType("varchar(255)");
        builder.Property(x => x.Phone).IsRequired().HasColumnName("phone").HasColumnType("varchar(20)"); 
        builder.Property(x => x.DateOfBirth).IsRequired().HasColumnName("dateOfBirth").HasColumnType("date");
        builder.Property(x => x.HireDate).IsRequired().HasColumnName("hireDate").HasColumnType("date");
        builder.Property(x => x.Position).IsRequired().HasColumnName("position").HasColumnType("varchar(100)");
        builder.Property(x => x.Salary).IsRequired().HasColumnName("salary").HasColumnType("decimal(18, 2)");
        builder.Property(x => x.DepartmentName).IsRequired().HasColumnName("departmentName").HasColumnType("varchar(100)");
        builder.Property(x => x.ManagerName).IsRequired().HasColumnName("managerName").HasColumnType("varchar(100)");
        builder.Property(x => x.IsActive).IsRequired().HasColumnName("isActive").HasColumnType("boolean").HasDefaultValue(true);
        builder.Property(x => x.Address).IsRequired().HasColumnName("address").HasColumnType("varchar(255)");
        builder.Property(x => x.City).IsRequired().HasColumnName("city").HasColumnType("varchar(100)");
        builder.Property(x => x.Country).IsRequired().HasColumnName("country").HasColumnType("varchar(100)");
        builder.Property(x => x.CreatedAt).IsRequired().HasColumnName("createdAt").HasColumnType("varchar(100)").HasDefaultValueSql("current_timestamp");
        builder.Property(x => x.UpdatedAt).IsRequired().HasColumnName("updatedAt").HasColumnType("varchar(100)").HasDefaultValueSql("current_timestamp");
    }
}