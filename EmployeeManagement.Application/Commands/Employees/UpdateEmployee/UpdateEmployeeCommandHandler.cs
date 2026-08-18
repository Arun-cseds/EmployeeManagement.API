using AutoMapper;
using EmployeeManagement.Application.Commands.Employees.CreateEmployee;
using EmployeeManagement.Core.Abstraction.Repositories;
using EmployeeManagement.Core.DTOs;
using EmployeeManagement.Core.Entities;
using MediatR;

namespace EmployeeManagement.Application.Commands.Employees.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper) :IRequestHandler<UpdateEmployeeCommand, EmployeeDto >
    {

        

        public Task<EmployeeDto> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {

            var employee = mapper.Map<Employee>(request);
            return employeeRepository.UpdateAsync(employee,request.Id);
            
        }
    }
}
