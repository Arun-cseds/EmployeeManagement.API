using EmployeeManagement.Core.DTOs;
using EmployeeManagement.Core.Entities;

namespace EmployeeManagement.Core.Abstraction.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployees();

        Task<Employee?> GetEmployeeById(int employeeId);

       // Task<Employee ?> AddEmployee(CreateEmployeeDto dto);
        Task<Employee> AddEmployee(Employee employee);

         Task<bool> DeleteEmployee(int employeeId);
        Task<EmployeeDto?> UpdateAsync(Employee employee, int Id);
    }
}
