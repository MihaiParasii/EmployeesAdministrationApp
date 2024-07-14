using Microsoft.EntityFrameworkCore;
using TestProjectRazorModels;

namespace TestProjectRazor.Services;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext
{
    public DbSet<Employee> Employees { get; init; }
    public DbSet<Department> Departments { get; init; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var serverVersion = new MySqlServerVersion(new Version(8, 3, 0));
        const string connectionString = "server=localhost;user=root;password=;database=TestProjectRazor";
        optionsBuilder.UseMySql(connectionString, serverVersion);
    }
}
