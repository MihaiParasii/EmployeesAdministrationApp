using Microsoft.AspNetCore.Mvc.RazorPages;
using TestProjectRazor.Services;
using TestProjectRazorModels;

namespace TestProjectRazor.Pages.Departments;

public class IndexModel(IRepository<Department> repository) : PageModel
{
    public IEnumerable<Department>? Departments { get; set; }
    
    public async Task OnGet()
    {
        Departments = await repository.GetAllAsync();
    }
}
