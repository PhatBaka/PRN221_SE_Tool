using System;

namespace SETool_RazorPage.ViewModel
{
    public class GroupProjectViewModel
    {
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Status { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedDate { get; set; }
    }
}
