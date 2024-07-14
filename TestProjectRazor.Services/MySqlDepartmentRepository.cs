using Microsoft.EntityFrameworkCore;
using TestProjectRazorModels;

namespace TestProjectRazor.Services;

public class MySqlDepartmentRepository(AppDbContext context) : IRepository<Department>
{
    public IEnumerable<Department> GetAll()
    {
        return context.Departments.ToList();
    }

    public async Task<IEnumerable<Department>> GetAllAsync()
    {
        return await context.Departments.ToListAsync();
    }

    public async Task<IEnumerable<Department>> SearchAsync(string query)
    {
        return await context.Departments.Where(e => e.Name.Contains(query)).ToListAsync();
    }

    public async Task<Department?> GetByIdAsync(int id)
    {
        return await context.Departments.FirstOrDefaultAsync(d => d.DepartmentId == id);
    }

    public async Task<Department> UpdateAsync(Department entity)
    {
        context.Departments.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(Department entity)
    {
        var result = context.Departments.Remove(entity);
        await context.SaveChangesAsync();
        return result.State == EntityState.Deleted;
    }

    public async Task<Department> AddAsync(Department entity)
    {
        context.Departments.Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public Task<IEnumerable<DepartmentHeadCount>> CountHeadsByDepartmentAsync(Department? department)
    {
        throw new NotImplementedException();
    }
}
