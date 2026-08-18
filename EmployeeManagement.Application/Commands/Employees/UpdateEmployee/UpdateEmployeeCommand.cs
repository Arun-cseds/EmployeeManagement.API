
using EmployeeManagement.Core.DTOs;
using MediatR;
namespace EmployeeManagement.Application.Commands.Employees.UpdateEmployee
{
    public class UpdateEmployeeCommand :IRequest<EmployeeDto>
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;


        public string Email { get; set; } = string.Empty;

        public int DepartmentId { get; set; }


    }
}
