namespace TestProjectRazorModels;

public class DepartmentHeadCount
{
    public DepartmentHeadCount(Department? department, int countEmployees)
    {
        Department = department;
        CountEmployees = countEmployees;
    }

    public DepartmentHeadCount()
    {
    }


    public Department? Department { get; set; }
    public int CountEmployees { get; set; }
}
