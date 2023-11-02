using AutoMapper;
using Microsoft.Extensions.Logging;
using SETool_Data.DAOs;
using SETool_Data.Helpers.Logger;
using SETool_Data.Models.Constants.Enums;
using SETool_Data.Models.DTOs;
using SETool_Data.Models.Entities;
using SETool_Data.Repositories.IRepos;
using SETool_Data.Repositories.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SETool_Business.Services.Impls
{
    public class ProjectService : IProjectService
    {
        private readonly ITeacherProjectRepository _teacherProjectrepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IGenericRepository<Project> _genericProjectRepository;
        private readonly IGenericRepository<TeacherProject> _genericTeacherProjectRepository;
        private readonly IMapper _mapper;

        public ProjectService(ITeacherProjectRepository teacherProjectRepository
                                , IProjectRepository projectRepository
                                , IGenericRepository<Project> genericProjectRepository
                                , IGenericRepository<TeacherProject> genericTeacherProjectRepository
                                , IMapper mapper)
        {
            _teacherProjectrepository = teacherProjectRepository;
            _projectRepository = projectRepository;
            _genericProjectRepository = genericProjectRepository;
            _genericTeacherProjectRepository = genericTeacherProjectRepository;
            _mapper = mapper;
        }

        public async System.Threading.Tasks.Task CreateProject(CreateProjectDTO projectDTO, GetUserDTO coreTeacher, List<GetUserDTO> sideTeachers)
        {
            try
            {
                // create new project
                Project project = _mapper.Map<Project>(projectDTO);
                project.Status = "IN PENDING";
                await _genericProjectRepository.Insert(project);
                GetProjectDTO getProjectDTO = await GetProjectByName(projectDTO.Name);

                // create new teacher project 
                CreateTeacherProjectDTO coreTeacherProjectDTO = new()
                {
                    ProjectId = getProjectDTO.Id,
                    TeacherId = coreTeacher.id,
                    IsCoreTeacher = true,
                    Status = "ACTIVE"
                };

                if (sideTeachers != null)
                {
                    // assign "side" teacher
                    foreach (var sideTeacher in sideTeachers)
                    {
                        CreateTeacherProjectDTO sideTeacherProjectDTO = new()
                        {
                            ProjectId = getProjectDTO.Id,
                            TeacherId = sideTeacher.id,
                            IsCoreTeacher = false,
                            Status = "PENDING"
                        };
                        TeacherProject sideTeacherProject = _mapper.Map<TeacherProject>(sideTeacherProjectDTO);
                        await _genericTeacherProjectRepository.Insert(sideTeacherProject);
                    }
                }
                TeacherProject coreTeacherProject = _mapper.Map<TeacherProject>(coreTeacherProjectDTO);
                await _genericTeacherProjectRepository.Insert(coreTeacherProject);
            }
            catch (Exception ex)
            {
                LoggerService.Logger(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<GetProjectDTO>> GetAll()
        {
            try
            {
                IEnumerable<Project> projects = await _projectRepository.GetAll();
                IEnumerable<GetProjectDTO> projectDTOs = _mapper.Map<IEnumerable<GetProjectDTO>>(projects);
                return projectDTOs;
            }   
            catch (Exception ex)
            {
                LoggerService.Logger(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetProjectDTO> GetProjectByName(string name)
        {
            try
            {
                Project project = await _projectRepository.GetProjectByName(name);
                GetProjectDTO projectDTO = _mapper.Map<GetProjectDTO>(project);
                return projectDTO;
            }
            catch (Exception ex)
            {
                LoggerService.Logger(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<GetProjectDTO>> GetProjectsByCoreTeacherId(int Id)
        {
            try
            {
                List<Project> projects = new List<Project>();
                IEnumerable<TeacherProject> teacherProjects = await _teacherProjectrepository.GetTeacherProjectByTeacherId(Id);
                IEnumerable<GetTeacherProjectDTO> teacherProjectDTO = _mapper.Map<IEnumerable<GetTeacherProjectDTO>>(teacherProjects);
                foreach (var teacherProject in teacherProjectDTO)
                {
                    projects.Add(await _projectRepository.GetProjectById(teacherProject.ProjectId));
                }
                return _mapper.Map<IEnumerable<GetProjectDTO>>(projects);
            }
            catch (Exception ex)
            {
                LoggerService.Logger(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
