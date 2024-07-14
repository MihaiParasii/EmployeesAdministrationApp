using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestProjectRazor.Services;

namespace TestProjectRazor.Pages.Departments;

public class CreateModel(IDepartmentRepository departmentRepository) : PageModel
{
    [BindProperty] public TestProjectRazorModels.Department Department { get; set; }

    public IActionResult OnGet()
    {
        Department = new TestProjectRazorModels.Department();
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            TempData["error"] = $"Error: {ModelState.ErrorCount}";
            return Page();
        }


        departmentRepository.Add(Department);
        TempData["SuccessMessage"] = $"Add {Department.Name} successfully";

        return RedirectToPage("/Employees/index");
    }
}
