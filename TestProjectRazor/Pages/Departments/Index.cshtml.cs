using Microsoft.AspNetCore.Mvc.RazorPages;
using TestProjectRazor.Services;

namespace TestProjectRazor.Pages.Departments;

public class IndexModel(IDepartmentRepository db) : PageModel
{
    public IEnumerable<TestProjectRazorModels.Department>? Departments { get; set; }
    
    public void OnGet()
    {
        Departments = db.GetDepartments();
    }
}
