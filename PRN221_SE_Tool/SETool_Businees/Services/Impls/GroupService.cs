using AutoMapper;
using Microsoft.VisualBasic;
using SETool_Business.Services.Extensions;
using SETool_Data.DAOs;
using SETool_Data.Helpers.Logger;
using SETool_Data.Models.Constants;
using SETool_Data.Models.DTOs;
using SETool_Data.Models.Entities;
using SETool_Data.Repositories.IRepos;
using SETool_Data.Repositories.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Business.Services.Impls
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IGenericRepository<Group> _groupGenericRepository;
        private readonly IGenericRepository<User> _userGenericRepository;

        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;

        public GroupService(IGroupRepository groupRepository,
                            IValidationService validationService,
                            IGenericRepository<Group> groupGenericRepository,
                            IGenericRepository<User> userGenericRepository,
                            IMapper mapper)
        {
            _groupGenericRepository = groupGenericRepository;
            _groupRepository = groupRepository;
            _validationService = validationService;
            _mapper = mapper;
            _userGenericRepository = userGenericRepository;
        }



        public async System.Threading.Tasks.Task CreateGroup(CreateGroupDTO createGroupDTO, List<GetUserDTO> studentDTOs)
        {
            // Create new group
            try
            {
                // create new group
                Group group = _mapper.Map<Group>(createGroupDTO);
                await _groupGenericRepository.Insert(group);
                group = await _groupRepository.GetGroupByLeaderId(createGroupDTO.LeaderId);
                User user;
                foreach(var item in studentDTOs)
                {
                    user = await _userGenericRepository.GetById(item.Id);
                    user.GroupId = group.Id;
                    await _userGenericRepository.Update(user);
                }
            }
            catch (Exception ex)
            {
                LoggerService.Logger(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetGroupDTO> GetGroupByUserId(int id)
        {
            try
            {
                User user = await _userGenericRepository.GetById(id);
                Group group = await _groupGenericRepository.GetById(user.GroupId);
                return _mapper.Map<GetGroupDTO>(group);
            }
            catch (Exception ex)
            {
                LoggerService.Logger(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
