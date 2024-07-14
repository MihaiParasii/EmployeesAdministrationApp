using Microsoft.AspNetCore.Mvc;
using TestProjectRazor.Services;
using TestProjectRazorModels;

namespace TestProjectRazor.Pages.ViewComponents;

public class HeadCountViewComponent(IRepository<Employee> repository) : ViewComponent
{
    public IViewComponentResult Invoke(Department? department)
    {
        var result = repository.CountHeadsByDepartmentAsync(department);
        return View(result.Result);
    }
}
