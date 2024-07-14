using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestProjectRazor.Services;
using TestProjectRazorModels;

namespace TestProjectRazor.Pages.Employees;

public class IndexModel(IRepository<Employee> repository) : PageModel
{
    public IEnumerable<Employee>? Employees { get; set; }
    [BindProperty(SupportsGet = true)] public string Query { get; set; } = null!;

    public async Task OnGet()
    {
        if (string.IsNullOrWhiteSpace(Query))
        {
            Employees = await repository.GetAllAsync();
        }
        else
        {
            Employees = await repository.SearchAsync(Query);
        }
    }
}
