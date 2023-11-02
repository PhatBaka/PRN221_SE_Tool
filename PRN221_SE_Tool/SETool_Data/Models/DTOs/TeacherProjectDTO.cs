using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Data.Models.DTOs
{
    public class TeacherProjectDTO
    {
        public int TeacherId { get; set; }
        public int ProjectId { get; set; }
        public bool IsCoreTeacher { get; set; }
        public string Status { get; set; }
    }
    public class CreateTeacherProjectDTO : TeacherProjectDTO
    {

    }
    public class UpdateTeacherProjectDTO : TeacherProjectDTO
    {
        
    }
    public class GetTeacherProjectDTO : TeacherProjectDTO
    {
        
    }
}
