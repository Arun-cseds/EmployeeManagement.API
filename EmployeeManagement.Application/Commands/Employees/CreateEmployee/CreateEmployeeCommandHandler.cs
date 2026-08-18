using EmployeeManagement.Core.Abstraction.Repositories;
using EmployeeManagement.Core.DTOs;
using AutoMapper;
using EmployeeManagement.Core.Entities;
using MediatR;

namespace EmployeeManagement.Application.Commands.Employees.CreateEmployee
{
    public  class CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper):IRequestHandler<CreateEmployeeCommand, CreateEmployeeDto>
    {
        

        public async Task<CreateEmployeeDto> Handle(CreateEmployeeCommand emp, CancellationToken cancellationToken)
        {
            var employee = mapper.Map<Employee>(emp);
            var res = await employeeRepository.AddEmployee(employee);

            return mapper.Map<CreateEmployeeDto>(res);
        }

    }
}
 