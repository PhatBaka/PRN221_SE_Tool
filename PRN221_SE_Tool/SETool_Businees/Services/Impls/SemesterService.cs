using AutoMapper;
using SETool_Business.Services.Extensions;
using SETool_Data.DAOs;
using SETool_Data.Extensions;
using SETool_Data.Helpers.Logger;
using SETool_Data.Models.Constants.Enums;
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
    public class SemesterService : ISemesterService
    {
        private readonly ISemesterRepository _semesterRepository;
        private readonly IGenericRepository<Semester> _semesterGenericRepository;

        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;

        public SemesterService(ISemesterRepository semesterRepository
                                , IGenericRepository<Semester> semesterGenericRepository
                                , IValidationService validationService
                                , IMapper mapper)
        {
            _semesterRepository = semesterRepository;
            _semesterGenericRepository = semesterGenericRepository;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<GetSemesterDTO> CreateSemester()
        {
            try
            {
                CreateSemesterDTO semesterDTO = new CreateSemesterDTO()
                {
                    Name = DateTimePicker.CreateSemesterString(DateTimePicker.GetCurrentVacation()),
                    Status = "ACTIVE",
                    StartDate = (DateTime)DateTimePicker.GetFirstDateOfSemester(DateTimePicker.GetCurrentVacation()),
                    EndDate = (DateTime)DateTimePicker.GetLastDateOfSemester(DateTimePicker.GetCurrentVacation())
                };
                Semester entity = _mapper.Map<Semester>(semesterDTO);
                await _semesterGenericRepository.Insert(entity);
                return _mapper.Map<GetSemesterDTO>(await _semesterRepository.GetSemesterByName(semesterDTO.Name));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<GetSemesterDTO>> GetAll()
        {
            try
            {
                var semesters = await _semesterGenericRepository.GetAll();
                return _mapper.Map<IEnumerable<GetSemesterDTO>>(semesters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GetSemesterDTO> GetCurrentSemester()
        {
            try
            {
                // Get active semester
                IEnumerable<GetSemesterDTO> semesters = await GetAll();
                if (semesters.Count() != 0)
                {
                    var activeSemester = semesters.FirstOrDefault(s => s.Status == "ACTIVE");
                    // Check semester time is now or not
                    if (DateTimePicker.CheckDateTimeInRange(activeSemester.StartDate, activeSemester.EndDate))
                        return activeSemester;
                    else // If now has pass active semester
                    {
                        // inactive pass semester
                        activeSemester.Status = "INACTIVE";
                        await _semesterGenericRepository.Update(_mapper.Map<Semester>(activeSemester));
                    }
                }
                return await CreateSemester();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
