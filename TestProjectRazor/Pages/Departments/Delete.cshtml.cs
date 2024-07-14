using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestProjectRazor.Services;
using TestProjectRazorModels;

namespace TestProjectRazor.Pages.Departments;

public class Delete(IRepository<Department> departmentRepository, IRepository<Employee> employeeRepository) : PageModel
{
    [BindProperty] public Department? Department { get; set; }

    public async Task<IActionResult> OnGet(int id)
    {
        Department = await departmentRepository.GetByIdAsync(id);

        var countEmployeesInThisDepartment = await employeeRepository.CountHeadsByDepartmentAsync(Department);

        if (Department == null)
        {
            return RedirectToPage("/NotFound");
        }


        if (countEmployeesInThisDepartment.Any())
        {
            ViewData["existsEmployees"] = true;
        }
        else
        {
            ViewData["existsEmployees"] = false;
        }

        return Page();
    }

    public async Task<IActionResult> OnPost(int id)
    {
        Department = await departmentRepository.GetByIdAsync(id);

        string departmentName = Department.Name;

        if (await departmentRepository.DeleteAsync(Department))
        {
            TempData["SuccessMessage"] = $"Delete {departmentName} successfully";
        }
        else
        {
            TempData["ErrorMessage"] = $"Failed to delete {departmentName}";
        }

        return RedirectToPage("/Employees/Index");
    }
}
