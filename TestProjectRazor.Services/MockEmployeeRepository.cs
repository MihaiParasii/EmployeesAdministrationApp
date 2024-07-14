// using Microsoft.AspNetCore.Mvc.Rendering;
// using TestProjectRazorModels;
//
// namespace TestProjectRazor.Services;
//
// public class MockEmployeeRepository : IEmployeeRepository
// {
//     private readonly List<Employee> _employeesList =
//     [
//         CreateEmployee(1, "John", "John", "john@gmail.com", new DateOnly(2000, 01, 01), new Department { Name = "HR" },
//             "avatar.png"),
//         CreateEmployee(2, "Michael", "Jordan", "michael@gmail.com", new DateOnly(2003, 03, 03),
//             new Department { Name = "Backend" }, "avatar2.png"),
//         CreateEmployee(3, "Nicolae", "Sulac", "nicu.sulac@gmail.com", new DateOnly(1999, 09, 09),
//             new Department { Name = "FrontEnd" }, "avatar3.png"),
//         CreateEmployee(4, "Keanu", "Reeves", "keanu@gmail.com", new DateOnly(1999, 09, 09),
//             new Department { Name = "iOS" })
//     ];
//
//     public IEnumerable<Employee> GetAllEmployees()
//     {
//         return _employeesList;
//     }
//
//     public IEnumerable<Employee> Search(string query)
//     {
//         return _employeesList.Where(e =>
//                 e.Name.Contains(query, StringComparison.CurrentCultureIgnoreCase) ||
//                 e.SurName.Contains(query, StringComparison.CurrentCultureIgnoreCase) ||
//                 e.Email.Contains(query, StringComparison.CurrentCultureIgnoreCase))
//             .ToList();
//     }
//
//     public Employee GetEmployeeById(int id)
//     {
//         return _employeesList.FirstOrDefault(e => e.Id == id)!;
//     }
//
//     public Employee Update(Employee employee)
//     {
//         Employee? currentEmployee = GetEmployeeById(employee.Id);
//
//         if (currentEmployee == null!)
//         {
//             return employee;
//         }
//
//         currentEmployee.Name = employee.Name;
//         currentEmployee.SurName = employee.SurName;
//         currentEmployee.Email = employee.Email;
//         currentEmployee.BirthDate = employee.BirthDate;
//         currentEmployee.Department = employee.Department;
//         currentEmployee.PhotoPath = employee.PhotoPath;
//
//         return employee;
//     }
//
//     public bool Delete(Employee employee)
//     {
//         _employeesList.Remove(employee);
//         return true;
//     }
//
//     public Employee Add(Employee employee)
//     {
//         employee.Id = _employeesList.Max(e => e.Id) + 1;
//         _employeesList.Add(employee);
//         return employee;
//     }
//
//     public IEnumerable<DepartmentHeadCount> CountHeadsByDepartment(Department? department)
//     {
//         IEnumerable<Employee> query = _employeesList;
//
//         if (department != null)
//         {
//             query = query.Where(e => e.Department.Name.Equals(department.Name));
//         }
//
//         return query
//             .GroupBy(x => x.Department)
//             .Select(g => new DepartmentHeadCount(g.Key, g.Count()))
//             .ToList();
//     }
//
//
//     private static Employee CreateEmployee(int id, string name, string surname, string email, DateOnly birthDate,
//         Department department,
//         string? photoPath = null)
//     {
//         return new Employee
//         {
//             Id = id,
//             Name = name,
//             SurName = surname,
//             Email = email,
//             BirthDate = birthDate,
//             PhotoPath = photoPath,
//             Department = department
//         };
//     }
// }
