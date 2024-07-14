using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestProjectRazor.Services;
using TestProjectRazorModels;

namespace TestProjectRazor.Pages.Employees;

public class DetailsModel(IRepository<Employee> repository) : PageModel
{
    public Employee? Employee { get; set; }

    public async Task<IActionResult> OnGet(int id)
    {
        Employee = await repository.GetByIdAsync(id);

        if (Employee == null)
        {
            return RedirectToPage("/NotFound");
        }

        return Page();
    }
}
