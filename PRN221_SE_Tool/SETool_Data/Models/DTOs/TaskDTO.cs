using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Data.Models.DTOs
{
    //public int Id { get; set; }
    //public string Name { get; set; }
    //public DateTime? StartDate { get; set; }
    //public DateTime? EndDate { get; set; }
    //public string Description { get; set; }
    //public DateTime? AssignedDate { get; set; }
    //public int? AssignedById { get; set; }
    //public string Resouce { get; set; }
    //public int? MilestoneId { get; set; }
    //public int? AssignedToId { get; set; }
    //public string Status { get; set; }

    public class TaskDTO
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public DateTime AssignedDate { get; set; }
        public string Status { get; set; }  
    }

    public class CreateTaskDTO : TaskDTO
    {
        public int AssignedById { get; set; }
        public int AssignedToId { get; set; }
        public int MilestoneId { get; set; }
    }

    public class UpdateTaskDTO : TaskDTO
    {
        public int AssignedToId { get; set; }
        public string Resouce { get; set; }
    }

    public class GetTaskDTO : TaskDTO
    {
        public int Id { get; set; }
        public GetUserDTO AssignedById { get; set; }
        public GetUserDTO AssignedToId { get; set; }
        public string Resouce { get; set; }
    }
}
