using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project3_FinalExam.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Project3_FinalExam.Services;
using Project3_FinalExam.ViewModels;

namespace Project3_FinalExam.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetFaculty _facultyRepository;
        private readonly IGetStaff _staffRepository;
        private readonly IGetAbout _aboutRepository;
        private readonly IGetEmployment _employmentRepository;
        private readonly IGetGraduate _graduateRepository;
        private readonly IGetMinors _minorsRepository;
        private readonly IGetUndergrad _underRepository;

        public HomeController(IGetUndergrad underRepository, IGetMinors minorsRepository, IGetGraduate graduateRepository, IGetFaculty facultyRepository, IGetStaff staffRepository, IGetAbout aboutRepository, IGetEmployment employmentRepository)
        {
            _facultyRepository = facultyRepository;
            _staffRepository = staffRepository;
            _aboutRepository = aboutRepository;
            _employmentRepository = employmentRepository;
            _graduateRepository = graduateRepository;
            _minorsRepository = minorsRepository;
            _underRepository = underRepository;
        }

        public async Task<IActionResult> Index()
        {
            var about = await _aboutRepository.GetAboutInfo();
            var homeViewModel = new HomeViewModel()
            {
                AboutInfo = about,
                Title = "Welcome to the iSchool Home Page!"
            };
            return View(homeViewModel);
        }

        public async Task<IActionResult> GetFaculty()
        {
            var allFaculty = await _facultyRepository.GetAllFaculty();
            var sortedFaculty = allFaculty.OrderBy(f => f.username);
            var homeViewModel = new HomeViewModel()
            {
                Faculty = allFaculty.ToList(),
                Title = "This is your Faculty"
            };
            return View(homeViewModel);
        }

        public async Task<IActionResult> GetStaff()
        {
            var allStaff = await _staffRepository.GetAllStaff();
            var sortedStaff = allStaff.OrderBy(s => s.username);
            var homeViewModel = new HomeViewModel()
            {
                Staff = allStaff.ToList(),
                Title = "This is your Staff"
            };
            return View(homeViewModel);
        }

        public async Task<IActionResult> Under()
        {
            var under = await _underRepository.GetUnderGradDegrees();
            var underViewModel = new UndergradViewModel()
            {
                UnderGrads = under,
                Title = "Undergraduate Programs"
            };
            return View(underViewModel);
        }

        public async Task<IActionResult> Grad()
        {
            var grad = await _graduateRepository.GetGradDegrees();
            var gradViewModel = new GradViewModel()
            {
                Grads = grad,
                Title = "Graduate Programs"
            };
            return View(gradViewModel);
        }

        public async Task<IActionResult> GetMinors()
        {
            var minors = await _minorsRepository.GetAllMinors();
            var minorsViewModel = new MinorsViewModel()
            {
                Minors = minors,
                Title = "Minors"
            };
            return View(minorsViewModel);

        }

        public async Task<IActionResult> GetEmploymentTable()
        {
            var employTable = await _employmentRepository.GetEmploymentTable();
            var employTableViewModel = new EmploymentTableViewModel()
            {
                employmentTable = employTable,
                Title = "Employment Table"
            };
            return View(employTableViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
