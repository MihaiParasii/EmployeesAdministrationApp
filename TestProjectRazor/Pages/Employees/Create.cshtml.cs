using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestProjectRazor.Services;
using TestProjectRazorModels;

namespace TestProjectRazor.Pages.Employees;

public class Create(
    IRepository<Employee> employeeRepository,
    IRepository<Department> departmentRepository,
    IWebHostEnvironment environment) : PageModel
{
    [BindProperty] public Employee Employee { get; set; }
    [BindProperty] public IFormFile? Photo { get; set; }
    [BindProperty] public int EmployeeDepartmentId { get; set; }
    public IEnumerable<Department> Departments = departmentRepository.GetAll();


    public IActionResult OnGet()
    {
        Employee = new Employee
        {
            Name = null!,
            SurName = null,
            Email = null,
            BirthDate = new DateOnly(2000, 1, 1),
        };
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
            Employee.PhotoPath = ProcessUploadedFile();
        }

        await employeeRepository.AddAsync(Employee);

        TempData["SuccessMessage"] = $"Add {Employee.Name} {Employee.SurName} successfully";

        return RedirectToPage("/Employees/index");
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
