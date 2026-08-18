using EmployeeManagement.Core.Entities;
using EmployeeManagement.Core.Abstraction.Repositories;
using EmployeeManagement.Core.DTOs;
using AutoMapper;

namespace EmployeeManagement.Application.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        private readonly IMapper _mapper;
        public  EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;

            _mapper=mapper;

        }

   
        public async Task<List<EmployeeDto>> GetAllEmployees()


        {
            var res= await _employeeRepository.GetAllEmployees();

            return _mapper.Map<List<EmployeeDto>>(res);

          
        }
      public async   Task<EmployeeDto?> GetEmployeeById(int employeeId)
        {
            var res=await _employeeRepository.GetEmployeeById(employeeId);

            return _mapper.Map<EmployeeDto>(res);
        }

        public async Task<CreateEmployeeDto> AddEmployee(CreateEmployeeDto dto)
        {

            var employee=_mapper.Map<Employee>(dto);
            var res= await _employeeRepository.AddEmployee(employee);

            return _mapper.Map<CreateEmployeeDto>(res);
        }

        public async Task <bool>DeleteEmployee(int employeeId)
        {
         return   await _employeeRepository.DeleteEmployee(employeeId);

        }

    }
}
