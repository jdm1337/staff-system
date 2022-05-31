using AutoMapper;
using StaffSystem.Core.ProjectAggregate.Identity;
using StaffSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffSystem.Web.AutomapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(
                    dest => dest.Id,
                    from => from.MapFrom(x => x.Id)
                )
                .ForMember(
                    dest => dest.FirstName,
                    from => from.MapFrom(x => x.FirstName)
                )
                .ForMember(
                    dest => dest.Surname,
                    from => from.MapFrom(x => x.Surname)
                )
                .ForMember(
                    dest => dest.Patronymic,
                    from => from.MapFrom(x => x.Patronymic)
                )
                .ForMember(
                    dest => dest.Department,
                    from => from.MapFrom(x => x.Department)
                )
                .ForMember(
                    dest => dest.BirthDay,
                    from => from.MapFrom(x => x.BirthDay)
                )
                .ForMember(
                    dest => dest.Gender,
                    from => from.MapFrom(x => x.Gender)
                )
                .ForMember(
                    dest => dest.Position,
                    from => from.MapFrom(x => x.Position)
                )
                .ForMember(
                    dest => dest.CompanyName,
                    from => from.MapFrom(x => x.CompanyName)
                )
                .ForMember(
                    dest => dest.DepartmentName,
                    from => from.MapFrom(x => x.DepartmentName)
                )
                .ForMember(
                    dest => dest.ProjectName,
                    from => from.MapFrom(x => x.ProjectName)
                )
                .ForMember(
                    dest => dest.ControllerName,
                    from => from.MapFrom(x => x.ControllerName)
                );


            CreateMap<UserViewModel, User>()

                .ForMember(
                    dest => dest.FirstName,
                    from => from.MapFrom(x => x.FirstName)
                )
                .ForMember(
                    dest => dest.Surname,
                    from => from.MapFrom(x => x.Surname)
                )
                .ForMember(
                    dest => dest.Patronymic,
                    from => from.MapFrom(x => x.Patronymic)
                )
                .ForMember(
                    dest => dest.Department,
                    from => from.MapFrom(x => x.Department)
                )
                .ForMember(
                    dest => dest.BirthDay,
                    from => from.MapFrom(x => x.BirthDay)
                )
                .ForMember(
                    dest => dest.Gender,
                    from => from.MapFrom(x => x.Gender)
                )
                .ForMember(
                    dest => dest.Position,
                    from => from.MapFrom(x => x.Position)
                )
                .ForMember(
                    dest => dest.CompanyName,
                    from => from.MapFrom(x => x.CompanyName)
                )
                .ForMember(
                    dest => dest.DepartmentName,
                    from => from.MapFrom(x => x.DepartmentName)
                )
                .ForMember(
                    dest => dest.ProjectName,
                    from => from.MapFrom(x => x.ProjectName)
                )
                .ForMember(
                    dest => dest.ControllerName,
                    from => from.MapFrom(x => x.ControllerName)
                );
        }
    }
}
