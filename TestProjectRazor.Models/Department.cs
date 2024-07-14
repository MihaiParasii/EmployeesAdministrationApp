using System.ComponentModel.DataAnnotations;

namespace TestProjectRazorModels;

public class Department
{
    public Department()
    {
    }

    // [SetsRequiredMembers]
    public Department(string name)
    {
        Name = name;
    }

    public int DepartmentId { get; set; }

    [Required(ErrorMessage = "The department name is required!")]
    [MaxLength(20, ErrorMessage = "The department name is too long. It should be at least {0} characters")]
    public string Name { get; init; } = null!;

    public ICollection<Employee> Employees { get; set; } = [];

    public override string ToString() => Name;
}
