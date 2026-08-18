using MediatR;
using AutoMapper;
using EmployeeManagement.Core.DTOs;
namespace EmployeeManagement.Application.Queries.GetAllEmployee
{
public class GetEmployeeQuery:IRequest<List<EmployeeDto>>
    {


    }
}
