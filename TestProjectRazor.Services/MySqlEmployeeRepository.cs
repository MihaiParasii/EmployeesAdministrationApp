using Microsoft.EntityFrameworkCore;
using TestProjectRazorModels;

namespace TestProjectRazor.Services;

public class MySqlEmployeeRepository(AppDbContext context) : IEmployeeRepository
{
    public async Task<IEnumerable<Employee>> GetAllEmployees()
    {
        return await context.Employees.Include(e => e.Department).ToListAsync();
    }

    public async Task<IEnumerable<Employee>> Search(string query)
    {
        return await context.Employees
            .Where(e => e.Name.Contains(query) || e.SurName.Contains(query) || e.Email.Contains(query))
            .ToListAsync();
    }

    public async Task<Employee?> GetEmployeeById(int id)
    {
        return await context.Employees.Include(e => e.Department).FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Employee> Update(Employee employee)
    {
        context.Employees.Update(employee);
        await context.SaveChangesAsync();
        return employee;
    }

    public async Task<bool> Delete(Employee employee)
    {
        var result = context.Employees.Remove(employee);
        await context.SaveChangesAsync();
        return result.State == EntityState.Deleted;
    }

    public async Task<Employee> Add(Employee employee)
    {
        context.Employees.Add(employee);
        await context.SaveChangesAsync();
        return employee;
    }

    public async Task<IEnumerable<DepartmentHeadCount>> CountHeadsByDepartment(Department? department)
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


        // var query = await context.Employees.ToListAsync();
        //
        // if (department != null)
        // {
        //     query = query.Where(e => e.Department.Name.Equals(department.Name));
        // }
        //
        // return query
        //     .GroupBy(x => x.Department)
        //     .Select(g => new DepartmentHeadCount(g.Key, g.Count()));
        //     .ToListAsync();
    }
}
