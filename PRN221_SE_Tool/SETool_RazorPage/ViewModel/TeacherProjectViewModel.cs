using System.Collections.Generic;

namespace SETool_RazorPage.ViewModel
{
    public class TeacherProjectViewModel
    {
        public int Id;
        public string Name;
        public string Description;
        public string Status;
        public string Semester;
        public string CoreTeacher;
        public List<string> SideTeachers;
    }
}
