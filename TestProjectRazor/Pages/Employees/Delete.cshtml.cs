using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestProjectRazor.Services;
using TestProjectRazorModels;

namespace TestProjectRazor.Pages.Employees
{
    public class DeleteModel(IEmployeeRepository employeeRepository) : PageModel
    {
        public Employee? Employee { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Employee = await employeeRepository.GetEmployeeById(id);

            if (Employee != null)
            {
                return Page();
            }

            return RedirectToPage("/NotFound");
        }

        public async Task<RedirectToPageResult> OnPost(Employee employee)
        {
            employee = await employeeRepository.GetEmployeeById(employee.Id)!;
            
            string employeeName = employee.Name;
            string employeeSurname = employee.SurName;
            

            if (await employeeRepository.Delete(employee))
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
