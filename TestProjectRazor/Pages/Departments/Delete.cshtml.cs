using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestProjectRazor.Services;
using TestProjectRazorModels;

namespace TestProjectRazor.Pages.Departments;

public class Delete(IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository) : PageModel
{
    [BindProperty] public Department? Department { get; set; }

    public async Task<IActionResult> OnGet(int id)
    {
        Department = departmentRepository.GetDepartmentById(id);

        var countEmployeesInThisDepartment = await employeeRepository.CountHeadsByDepartment(Department);

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

    public IActionResult OnPost(int id)
    {
        Department = departmentRepository.GetDepartmentById(id);

        string departmentName = Department.Name;

        if (departmentRepository.Delete(Department))
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
