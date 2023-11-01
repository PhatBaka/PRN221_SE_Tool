using SETool_Data.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Business.Services
{
    public interface ISemesterService
    {
        // CREATE
        public Task<GetSemesterDTO> CreateSemester();
        // READ
        public Task<IEnumerable<GetSemesterDTO>> GetAll();
        public Task<GetSemesterDTO> GetCurrentSemester();
        // UPDATE
        // DELETE
    }
}
