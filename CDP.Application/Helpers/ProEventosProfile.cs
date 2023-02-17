using AutoMapper;
using CDP.Application.Dtos;
using CDP.Domain;
using CDP.Domain.Identity;

namespace CDP.Application.Helpers
{
    public class CDPProfile : Profile
    {
        public CDPProfile()
        {
            CreateMap<Farm, FarmDto>().ReverseMap();
            CreateMap<Plot, PlotDto>().ReverseMap();

            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, EmployeeAddDto>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
        }
    }
}