using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestProjectRazor.Services;
using TestProjectRazorModels;

namespace TestProjectRazor.Pages.Employees;

public class Edit(
    IRepository<Employee> employeeRepository,
    IRepository<Department> departmentRepository,
    IWebHostEnvironment environment) : PageModel
{
    [BindProperty] public Employee? Employee { get; set; }
    [BindProperty] public IFormFile? Photo { get; set; }
    [BindProperty] public int EmployeeDepartmentId { get; set; }

    public IEnumerable<Department> Departments = departmentRepository.GetAll();


    public async Task<IActionResult> OnGet(int id)
    {
        Employee = await employeeRepository.GetByIdAsync(id);

        if (Employee == null)
        {
            return RedirectToPage("/NotFound");
        }

        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        Employee.Department = await departmentRepository.GetByIdAsync(EmployeeDepartmentId);

        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (Photo != null)
        {
            if (Employee.PhotoPath != null)
            {
                string filePath = Path.Combine(environment.WebRootPath, "images", Employee.PhotoPath);
                System.IO.File.Delete(filePath);
            }

            Employee.PhotoPath = ProcessUploadedFile();
        }

        Employee = await employeeRepository.UpdateAsync(Employee);
        TempData["SuccessMessage"] = $"Update {Employee.Name} {Employee.SurName} successfully";

        return RedirectToPage($"/{nameof(Employees)}/{nameof(Index)}");
    }

    private string? ProcessUploadedFile()
    {
        string? uniqueFileName = null;

        if (Photo == null)
        {
            return uniqueFileName;
        }

        string uploadsFolder = Path.Combine(environment.WebRootPath, "images");
        uniqueFileName = Guid.NewGuid() + "_" + Photo.FileName;
        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

        using var fileStream = new FileStream(filePath, FileMode.Create);
        Photo.CopyTo(fileStream);

        return uniqueFileName;
    }
}
