using generic.app.api.Models;
using generic.app.applicationCore.Dtos;
using generic.app.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace generic.app.api.Mapper
{
    public class AutoMapping : AutoMapper.Profile
    {
        public AutoMapping()
        {
            CreateMap<Employees, EmployeesDto>().ReverseMap();
            CreateMap<Employees, EmployeesDto>().ReverseMap();
            CreateMap<EmployeesDto, EmployeesModel>().ReverseMap();
            CreateMap<EmployeesCreateModel, EmployeesDto>().ReverseMap();
            CreateMap<EmployeesUpdateModel, EmployeesDto>().ReverseMap();
        }
    }
}
