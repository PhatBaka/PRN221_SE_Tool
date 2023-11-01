using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Data.Models.DTOs
{
    public class SemesterDTO
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class CreateSemesterDTO : SemesterDTO
    {
        public string Status { get; set; }
    }
    public class GetSemesterDTO : SemesterDTO
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }
}
