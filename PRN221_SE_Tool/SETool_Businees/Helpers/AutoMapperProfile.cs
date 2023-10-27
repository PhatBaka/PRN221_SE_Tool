using AutoMapper;
using SETool_Data.Models.DTOs;
using SETool_Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Business.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, CreateUserDTO>().ReverseMap();
            CreateMap<User, UpdateUserDTO>().ReverseMap();
            CreateMap<User, GetUserDTO>().ReverseMap();

            CreateMap<Group, GroupDTO>().ReverseMap();
            CreateMap<Group, CreateGroupDTO>().ReverseMap();
            CreateMap<Group, UpdateGroupDTO>().ReverseMap();
            CreateMap<Group, GetGroupDTO>().ReverseMap();

            CreateMap<Role, RoleDTO>().ReverseMap();

        }
    }
}
