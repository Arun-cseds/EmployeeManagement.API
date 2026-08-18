using EmployeeManagement.Core.DTOs;
using MediatR;

namespace EmployeeManagement.Application.Commands.Employees.CreateEmployee
{
    public  class CreateEmployeeCommand:IRequest<CreateEmployeeDto>
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; }

        public string Email { get; set; } = string.Empty;

        public decimal Salary { get; set; }

        public int DepartmentId { get; set; }

        public int ProjectId { get; set; }
    }
}
