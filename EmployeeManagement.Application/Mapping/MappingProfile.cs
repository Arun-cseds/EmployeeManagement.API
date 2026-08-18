using AutoMapper;
using EmployeeManagement.Application.Commands.Employees.CreateEmployee;
using EmployeeManagement.Application.Commands.Employees.UpdateEmployee;
using EmployeeManagement.Core.DTOs;
using EmployeeManagement.Core.Entities;
using System.Runtime.InteropServices;
namespace EmployeeManagement.Application.Mapping
{
    public  class MappingProfile:Profile
    {

        public MappingProfile() {

            CreateMap<Employee, CreateEmployeeDto>();
            CreateMap<CreateEmployeeDto, Employee>();

            CreateMap<CreateEmployeeCommand, Employee>();
            CreateMap<Employee, CreateEmployeeCommand>();


            CreateMap<Employee, EmployeeDto>().ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => $" {src.FirstName} {src.LastName}")
                      ).ForMember(
                dest => dest.DepartmentName,
                opt => opt.MapFrom(src => src.Department != null
                    ? src.Department.DepartmentName
                    : string.Empty))
            .ForMember(

                dest => dest.ProjectName,
                opt => opt.MapFrom(src => src.Project != null
                    ? src.Project.ProjectName
                    : string.Empty));



            CreateMap<UpdateEmployeeCommand, Employee>();

               }
    }
}
