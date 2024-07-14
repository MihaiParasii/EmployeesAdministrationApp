using Microsoft.EntityFrameworkCore;
using TestProjectRazorModels;

namespace TestProjectRazor.Services;

public class MySqlEmployeeRepository(AppDbContext context) : IRepository<Employee>
{
    public IEnumerable<Employee> GetAll()
    {
        return context.Employees.ToList();
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await context.Employees.Include(e => e.Department).ToListAsync();
    }

    public async Task<IEnumerable<Employee>> SearchAsync(string query)
    {
        return await context.Employees
            .Where(e => e.Name.Contains(query) || e.SurName.Contains(query) || e.Email.Contains(query))
            .ToListAsync();
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        return await context.Employees.Include(e => e.Department).FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Employee> UpdateAsync(Employee entity)
    {
        context.Employees.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(Employee entity)
    {
        var result = context.Employees.Remove(entity);
        await context.SaveChangesAsync();
        return result.State == EntityState.Deleted;
    }

    public async Task<Employee> AddAsync(Employee entity)
    {
        context.Employees.Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<DepartmentHeadCount>> CountHeadsByDepartmentAsync(Department? department)
    {
        if (department == null)
        {
            return await context.Employees
                .GroupBy(x => x.Department)
                .Select(g => new DepartmentHeadCount(g.Key, g.Count()))
                .ToListAsync();
        }


        return await context.Employees.Where(e => e.Department.Name.Equals(department.Name))
            .GroupBy(x => x.Department)
            .Select(g => new DepartmentHeadCount(g.Key, g.Count()))
            .ToListAsync();
    }
}
