using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Profiles
{
    public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            CreateMap<Employee, EmployeeCreateDto>().ReverseMap();
            CreateMap<Employee, EmployeeReadDto>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateDto>().ReverseMap();
        }
    }
}
