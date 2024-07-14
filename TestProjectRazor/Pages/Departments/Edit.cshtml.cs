using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestProjectRazor.Services;
using TestProjectRazorModels;

namespace TestProjectRazor.Pages.Departments;

public class EditModel(IRepository<Department> repository) : PageModel
{
    [BindProperty] public Department? Department { get; set; }

    public async Task<IActionResult> OnGet(int id)
    {
        Department = await repository.GetByIdAsync(id);

        if (Department == null)
        {
            return RedirectToPage("/NotFound");
        }

        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
        {
            return RedirectToPage("/NotFound");
        }

        Department = await repository.UpdateAsync(Department!);
        TempData["SuccessMessage"] = $"Update {Department.Name} successfully";

        return RedirectToPage("/Departments/Index");
    }
}
