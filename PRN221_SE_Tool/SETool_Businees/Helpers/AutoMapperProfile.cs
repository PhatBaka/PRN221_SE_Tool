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
            // USER
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, CreateUserDTO>().ReverseMap();
            CreateMap<User, UpdateUserDTO>().ReverseMap();
            CreateMap<User, GetUserDTO>().ReverseMap();

            // GROUP
            CreateMap<Group, GroupDTO>().ReverseMap();
            CreateMap<Group, CreateGroupDTO>().ReverseMap();
            CreateMap<Group, UpdateGroupDTO>().ReverseMap();
            CreateMap<Group, GetGroupDTO>().ReverseMap();

            // ROLE
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<Role, GetRoleDTO>().ReverseMap();
            CreateMap<Role, CreateRoleDTO>().ReverseMap();

            // SEMESTER
            CreateMap<Semester, SemesterDTO>().ReverseMap();
            CreateMap<Semester, GetSemesterDTO>().ReverseMap();
            CreateMap<Semester, CreateSemesterDTO>().ReverseMap();

            // PROJECT
            CreateMap<Project, ProjectDTO>().ReverseMap();
            CreateMap<Project, GetProjectDTO>().ReverseMap();
            CreateMap<Project, CreateProjectDTO>().ReverseMap();
        }
    }
}
