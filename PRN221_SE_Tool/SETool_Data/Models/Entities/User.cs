using System;
using System.Collections.Generic;

#nullable disable

namespace SETool_Data.Models.Entities
{
    public partial class User
    {
        public User()
        {
            Tasks = new HashSet<Task>();
            TeacherProjects = new HashSet<TeacherProject>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public int? GroupId { get; set; }
        public int? RoleId { get; set; }

        public virtual Group Group { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<TeacherProject> TeacherProjects { get; set; }
    }
}
