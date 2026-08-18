using EmployeeManagement.Core.Abstraction.Repositories;
using EmployeeManagement.Core.Entities;
using MediatR;
using EmployeeManagement.Core.DTOs;
using AutoMapper;
namespace EmployeeManagement.Application.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper) : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
    {
        public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var emp= await employeeRepository.GetEmployeeById(request.Id);

            return mapper.Map<EmployeeDto>(emp);
        }
    }
}
