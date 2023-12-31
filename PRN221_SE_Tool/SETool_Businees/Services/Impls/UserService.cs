﻿using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;
using SETool_Business.Exceptions;
using SETool_Business.Services.Extensions;
using SETool_Data.DAOs;
using SETool_Data.Helpers.Logger;
using SETool_Data.Models.Constants;
using SETool_Data.Models.DTOs;
using SETool_Data.Models.Entities;
using SETool_Data.Repositories.IRepos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
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
            }
			catch (Exception ex)
			{
                LoggerService.Logger(ex.ToString());
                throw new Exception(ex.Message);
			}
		}


        public async System.Threading.Tasks.Task CreateUser(CreateUserDTO userDTO)
        {
            try
            {
                User entity = _mapper.Map<User>(userDTO);
                entity.Status = ObjectStatusConstant.ACTIVE;

                await _userGenericRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                LoggerService.Logger(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetUserDTO> GetUserByEmail(string email)
        {
            try
            {
                User user = await _userRepository.GetUserByEmail(email);
                GetUserDTO userDTO = _mapper.Map<GetUserDTO>(user);

                if (userDTO == null)
                {
                    return null;
                }

                return userDTO;
            }
            catch (Exception ex)
            {
                LoggerService.Logger(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetUserDTO> GetUserByPhone(string phone)
        {
            try
            {
                User user = await _userRepository.GetUserByPhone(phone);
                GetUserDTO userDTO = _mapper.Map<GetUserDTO>(user);

                if (userDTO == null)
                {
                    return null;
                }

                return userDTO;
            }
            catch (Exception ex)
            {
                LoggerService.Logger(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetUserDTO> GetUserById(int id)
        {
            try
            {
                User user = await _userRepository.GetUserById(id);
                GetUserDTO userDTO = _mapper.Map<GetUserDTO>(user);

                if (userDTO == null)
                {
                    return null;
                }

                return userDTO;
            }
            catch (Exception ex)
            {
                LoggerService.Logger(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<GetUserDTO>> GetUsersByGroupId(int groupId)
        {
            try
            {
                IEnumerable<User> users = await _userRepository.GetUsersByGroupId(groupId);
                IEnumerable<GetUserDTO> userDTOs = _mapper.Map<IEnumerable<GetUserDTO>>(users);

                if (userDTOs == null)
                {
                    return null;
                }

                return userDTOs;
            }
            catch (Exception ex)
            {
                LoggerService.Logger(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<GetUserDTO>> GetUsersNotHaveGroup()
        {
            try
            {
                IEnumerable<User> users = await _userRepository.GetUserNotHaveGroup();
                IEnumerable<GetUserDTO> userDTOs = _mapper.Map<IEnumerable<GetUserDTO>>(users);

                if (userDTOs == null)
                {
                    return null;
                }

                return userDTOs;
            }
            catch (Exception ex)
            {
                LoggerService.Logger(ex.ToString());
                throw new Exception(ex.Message);
            }
        }
    }
}
