using Microsoft.AspNetCore.Mvc;
using TestProjectRazor.Services;
using TestProjectRazorModels;

namespace TestProjectRazor.Pages.ViewComponents;

public class HeadCountViewComponent(IEmployeeRepository employeeRepository) : ViewComponent
{
    public IViewComponentResult Invoke(Department? department)
    {
        var result = employeeRepository.CountHeadsByDepartment(department);
        return View(result.Result);
    }
}
