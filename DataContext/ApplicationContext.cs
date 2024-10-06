using Exam9.DataConfig;
using Exam9.Entity;
using Microsoft.EntityFrameworkCore;

namespace Exam9.DataContext;

public class ApplicationContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfig).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}