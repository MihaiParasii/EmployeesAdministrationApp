using Microsoft.AspNetCore.Mvc.Rendering;
using TestProjectRazorModels;

namespace TestProjectRazor.Services;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetAllEmployees();
    Task<IEnumerable<Employee>> Search(string query);
    Task<Employee?> GetEmployeeById(int id);
    Task<Employee> Update(Employee employee);
    Task<bool> Delete(Employee employee);
    Task<Employee> Add(Employee employee);
    Task<IEnumerable<DepartmentHeadCount>> CountHeadsByDepartment(Department? department);
}
