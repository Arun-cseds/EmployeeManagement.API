using MediatR;

namespace EmployeeManagement.Application.Commands.Employees.DeleteEmployee
{
    public  class DeleteEmployeeCommand:IRequest<bool>
    {
       public int Id {  get; set; }

    }
}
