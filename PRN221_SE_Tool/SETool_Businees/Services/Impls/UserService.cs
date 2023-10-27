using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;
using SETool_Business.Exceptions;
using SETool_Business.Models;
using SETool_Business.Services.Extensions;
using SETool_Data.DAOs;
using SETool_Data.Helpers.Logger;
using SETool_Data.Models.Constants.Enums;
using SETool_Data.Models.DTOs;
using SETool_Data.Models.DTOs.CommonDTOs;
using SETool_Data.Models.Entities;
using SETool_Data.Repositories.IRepos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SETool_Business.Services.Impls
{
    public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IGenericRepository<User> _userGenericRepository;

		private readonly IValidationService _validationService;
		private readonly IMapper _mapper;

		public UserService(IUserRepository userRepository, 
							IValidationService validationService,
							IGenericRepository<User> genericUserRepository,
							IMapper mapper)
		{
			_userRepository = userRepository;
			_userGenericRepository = genericUserRepository;

			_validationService = validationService;
			_mapper = mapper;
		}

		public async Task<GetUserDTO> GetUserByEmailAndPassword(string email, string password)
		{
			try
			{
				User user = await _userRepository.GetUserByEmailAndPassowrd(email, password);
				GetUserDTO userDTO = _mapper.Map<GetUserDTO>(user);

				if (userDTO == null)
				{
					return null;
				}

                return userDTO;
                //	if (userDTO != null)
                //	{

                //		return userDTO;

                //	}
            }
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			
		}


		public async Task<IdDTO> CreateUser(CreateUserDTO userDTO, ThisUserObj currentUser)
		{
			IdDTO newId = new IdDTO();
			try
			{
				if (await _userRepository.GetUserByEmail(userDTO.email) != null)
					throw new InvalidFieldException("This email is existd");

				User entity = _mapper.Map<User>(userDTO);

				entity.Status = Enum.GetNames(typeof(ObjectStatusEnum)).ElementAt(0);

				newId.id = await _userGenericRepository.Insert(entity);

				if (newId.id.Equals(""))
					throw new CreateObjectException("Can not create user object");

				return newId;

			}
			catch (Exception ex)
			{
				LoggerService.Logger(ex.ToString());
				throw new Exception(ex.Message);
			}
		}
	}
}
