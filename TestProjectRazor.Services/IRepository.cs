using TestProjectRazorModels;

namespace TestProjectRazor.Services;

public interface IRepository<T>
{
    IEnumerable<T> GetAll();
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> SearchAsync(string query);
    Task<T?> GetByIdAsync(int id);
    Task<T> UpdateAsync(T entity);
    Task<bool> DeleteAsync(T entity);
    Task<T> AddAsync(T entity);
    Task<IEnumerable<DepartmentHeadCount>> CountHeadsByDepartmentAsync(Department? department);
}
