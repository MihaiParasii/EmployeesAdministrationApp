using Microsoft.EntityFrameworkCore;
using TestProjectRazorModels;

namespace TestProjectRazor.Services;

public class MySqlDepartmentRepository(AppDbContext context) : IDepartmentRepository
{
    public IEnumerable<Department> GetDepartments()
    {
        return context.Departments.ToList();
    }

    public Department? GetDepartmentById(int id)
    {
        return context.Departments.FirstOrDefault(d => d.DepartmentId == id);
    }

    public Department Add(Department department)
    {
        context.Departments.Add(department);
        context.SaveChanges();
        return department;
    }

    public Department Update(Department department)
    {
        context.Departments.Update(department);
        context.SaveChanges();
        return department;
    }

    public bool Delete(Department department)
    {
        var result = context.Departments.Remove(department);
        context.SaveChangesAsync();
        return result.State == EntityState.Deleted;
    }
}
