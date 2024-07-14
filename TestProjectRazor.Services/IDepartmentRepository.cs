using TestProjectRazorModels;

namespace TestProjectRazor.Services;

public interface IDepartmentRepository
{
    public IEnumerable<Department> GetDepartments();
    public Department? GetDepartmentById(int id);
    public Department Add(Department department);
    public Department Update(Department department);
    public bool Delete(Department department);
}
