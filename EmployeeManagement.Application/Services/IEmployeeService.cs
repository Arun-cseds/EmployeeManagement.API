using EmployeeManagement.Core.DTOs;
using EmployeeManagement.Core.Entities;

namespace EmployeeManagement.Application.Services
{
    public interface IEmployeeService
    {

    Task<List<EmployeeDto>>GetAllEmployees();
        Task<EmployeeDto?> GetEmployeeById(int employeeId);

        Task<CreateEmployeeDto> AddEmployee(CreateEmployeeDto dto);

        Task<bool> DeleteEmployee(int employeeId);


       
    }
}
