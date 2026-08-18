using EmployeeManagement.Core.Abstraction.Repositories;
using MediatR;

namespace EmployeeManagement.Application.Commands.Employees.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository):IRequestHandler<DeleteEmployeeCommand, bool>
    {
        public async  Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
           return await employeeRepository.DeleteEmployee(request.Id);
        }

        
    }
}
