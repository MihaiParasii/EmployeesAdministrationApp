using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestProjectRazor.Services;
using TestProjectRazorModels;

namespace TestProjectRazor.Pages.Departments;

public class CreateModel(IRepository<Department> repository) : PageModel
{
    [BindProperty] public Department Department { get; set; }

    public IActionResult OnGet()
    {
        Department = new Department();
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            TempData["error"] = $"Error: {ModelState.ErrorCount}";
            return Page();
        }


        repository.AddAsync(Department);
        TempData["SuccessMessage"] = $"Add {Department.Name} successfully";

        return RedirectToPage("/Employees/index");
    }
}
