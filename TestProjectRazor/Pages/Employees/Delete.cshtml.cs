using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestProjectRazor.Services;
using TestProjectRazorModels;

namespace TestProjectRazor.Pages.Employees
{
    public class DeleteModel(IRepository<Employee> repository) : PageModel
    {
        public Employee? Employee { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Employee = await repository.GetByIdAsync(id);

            if (Employee != null)
            {
                return Page();
            }

            return RedirectToPage("/NotFound");
        }

        public async Task<RedirectToPageResult> OnPost(Employee employee)
        {
            employee = await repository.GetByIdAsync(employee.Id)!;
            
            string employeeName = employee.Name;
            string employeeSurname = employee.SurName;
            

            if (await repository.DeleteAsync(employee))
            {
                TempData["SuccessMessage"] = $"Delete {employeeName} {employeeSurname} successfully";
            }
            else
            {
                TempData["ErrorMessage"] = $"Failed to delete {employeeName} {employeeSurname}";
            }

            return RedirectToPage("/Employees/Index");
        }
    }
}
