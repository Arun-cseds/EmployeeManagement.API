using EmployeeManagement.Core.Abstraction.Repositories;
using EmployeeManagement.Core.DTOs;
using EmployeeManagement.Core.Entities;
using EmployeeManagement.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeesDbContext _dbContext;
        private readonly IMapper _mapper;
        public EmployeeRepository(EmployeesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {

            //eager loading 
            var res = await _dbContext.Employees
                .Include(e => e.Department)
                .Include(e => e.Project)
                .OrderBy(e=>e.EmployeeId)
                .ToListAsync();



            return res;
        }

        public async Task<Employee?> GetEmployeeById(int employeeId)
        {

             var employee = await _dbContext.Employees
            .Include(e => e.Department)
            .Include(e => e.Project)
            .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
          //  var employee = await _dbContext.Employees.FindAsync(employeeId);

            return employee;

        }

        public async Task<Employee> AddEmployee(Employee employee)
        {


            await _dbContext.Employees.AddAsync(employee);

            await _dbContext.SaveChangesAsync();

            return employee;
        }



        public async Task<EmployeeDto?> UpdateAsync(Employee employee, int Id)
        {
            var existingEmployee = await _dbContext.Employees.FindAsync(Id);

            if (existingEmployee == null)
            {
                return null;
            }

            existingEmployee.FirstName = employee.FirstName;

            existingEmployee.LastName = employee.LastName;
            existingEmployee.Email = employee.Email;
            existingEmployee.DepartmentId = employee.DepartmentId;

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<EmployeeDto>(existingEmployee);
        }

        public async Task<bool> DeleteEmployee(int employeeId)
        {

            var emp = await _dbContext.Employees.FindAsync(employeeId);

            if(emp == null)
            {
                return false;
            }

            _dbContext.Employees.Remove(emp);

            await _dbContext.SaveChangesAsync();

            return true;



        }
    }
}

