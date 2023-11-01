using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SETool_Business.Services;
using SETool_Data.Models.DTOs;
using SETool_RazorPage.ViewModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SETool_RazorPage.Pages.Admins.Semesters
{
    public class IndexModel : PageModel
    {
        private readonly ISemesterService _semesterService;

        public IndexModel(ISemesterService semesterService)
        {
            _semesterService = semesterService;
        }

        public GetSemesterDTO CurrentSemester;
        public List<GetSemesterDTO> Semesters;
        public bool CheckSemester;

        public async Task<IActionResult> OnGet()
        {
            Semesters ??= new List<GetSemesterDTO>();
            CurrentSemester = await _semesterService.GetCurrentSemester();
            Semesters = (List<GetSemesterDTO>)await _semesterService.GetAll();
            return Page();
        }
    }
}
