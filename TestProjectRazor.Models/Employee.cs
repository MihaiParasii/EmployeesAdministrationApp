using System.ComponentModel.DataAnnotations;

namespace TestProjectRazorModels;

public class Employee
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The name filed can't be null")]
    [RegularExpression(@"^[a-zA-Z](?:[a-zA-Z.,'_ -]*[a-zA-Z])?$", ErrorMessage = "Invalid name")]
    [MinLength(3, ErrorMessage = "Name must contains at least 3 characters")]
    [MaxLength(15, ErrorMessage = "Name must contains at most 15 characters")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "The surname filed can't be null")]
    [RegularExpression(@"^[a-zA-Z](?:[a-zA-Z.,'_ -]*[a-zA-Z])?$", ErrorMessage = "Invalid surname")]
    [MinLength(3, ErrorMessage = "Surname must contains at least 3 characters")]
    [MaxLength(30, ErrorMessage = "Surname must contains at most 30 characters")]
    public required string SurName { get; set; }

    [Required(ErrorMessage = "The email filed can't be null")]
    [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid email")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "The birthDate filed can't be null")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [DateValidator]
    public required DateOnly BirthDate { get; set; }

    public string? PhotoPath { get; set; }

    // [Required(ErrorMessage = "You must select Department")]
    public Department? Department { get; set; }

    public override string ToString()
    {
        return $"{Id} | {Name}, {SurName}, {Email}, {BirthDate}, {Department}";
    }
}
