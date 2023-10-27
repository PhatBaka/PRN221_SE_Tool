using AutoMapper;
using SETool_Data.Helpers.Logger;
using SETool_Data.Models.DTOs;
using SETool_Data.Models.Entities;
using SETool_Data.Repositories.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Business.Services.Impls
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IGenericRepository<Role> _genericRoleRepository;

        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository
                            , IGenericRepository<Role> genericRoleRepository
                            , IMapper mapper)
        {
            _roleRepository = roleRepository;
            _genericRoleRepository = genericRoleRepository;
            _mapper = mapper;
        }

        public async Task<List<RoleDTO>> GetAllRoles()
        {
            try
            {
                IEnumerable<Role> roleList = await _genericRoleRepository.GetAll();
                List<RoleDTO> list = _mapper.Map<List<RoleDTO>>(roleList);
                return list;
            }
            catch (Exception e)
            {
                LoggerService.Logger(e.ToString());
                throw new Exception(e.Message);
            }
        }
    }
}
