using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestProjectRazor.Services;

namespace TestProjectRazor.Pages.Departments;

public class EditModel(IDepartmentRepository departmentRepository) : PageModel
{
    [BindProperty] public TestProjectRazorModels.Department? Department { get; set; }

    public IActionResult OnGet(int id)
    {
        Department = departmentRepository.GetDepartmentById(id);

        if (Department == null)
        {
            return RedirectToPage("/NotFound");
        }

        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return RedirectToPage("/NotFound");
        }

        Department = departmentRepository.Update(Department!);
        TempData["SuccessMessage"] = $"Update {Department.Name} successfully";

        return RedirectToPage("/Departments/Index");
    }
}
