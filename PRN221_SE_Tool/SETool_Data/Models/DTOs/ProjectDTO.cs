using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Data.Models.DTOs
{
    public class ProjectDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class CreateProjectDTO : ProjectDTO
    {
        public string Status { get; set; }
        public int SemesterId { get; set; }
    }
    public class GetProjectDTO : ProjectDTO
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public GetSemesterDTO Semester { get; set; }
    }
}
