using EmployeeManagement.Core.Entities;
using MediatR;
using EmployeeManagement.Core.DTOs;

namespace EmployeeManagement.Application.Queries.GetEmployeeById
{
    public  class GetEmployeeByIdQuery:IRequest<EmployeeDto>
    {

        public int Id { get; set; }
    }
}
