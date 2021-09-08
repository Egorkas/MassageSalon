using AutoMapper;
using MassageSalon.DAL.Common.Entities;
using MassageSalon.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassageSalon.WEB.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Employee, EmployeeModel>().ReverseMap(); 
            CreateMap<Masseur, MasseurModel>().ReverseMap();
            CreateMap<Record, RecordModel>().ReverseMap();
            CreateMap<Review, ReviewModel>().ReverseMap(); 
            CreateMap<Visitor, VisitorModel>().ReverseMap(); 
            CreateMap<Role, RoleModel>().ReverseMap(); 
        }
    }
}
