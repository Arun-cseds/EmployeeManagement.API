
using AutoMapper;
using EmployeeManagement.Core.Entities;
using EmployeeManagement.Core.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EmployeeManagement.Infrastructure.Mapping
{
    public  class MappingProfile:Profile
    {

        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ForMember(
                  dest => dest.Name,
                opt => opt.MapFrom(src => $" {src.FirstName} {src.LastName}")
                      );


        }
    }
}
