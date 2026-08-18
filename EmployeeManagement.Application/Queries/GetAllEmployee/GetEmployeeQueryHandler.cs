
using MediatR;
using AutoMapper;
using EmployeeManagement.Core.Abstraction.Repositories;
using EmployeeManagement.Core.DTOs;
namespace EmployeeManagement.Application.Queries.GetAllEmployee
{
    public class GetEmployeeQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper) : IRequestHandler<GetEmployeeQuery,List< EmployeeDto>>
    {
        public async  Task<List<EmployeeDto>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var res = await employeeRepository.GetAllEmployees();

            return mapper.Map<List<EmployeeDto>>(res);

        }
    }
}
