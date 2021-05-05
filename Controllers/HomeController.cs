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

        public HomeController(IGetFaculty facultyRepository)
        {
            _facultyRepository = facultyRepository;
        }

        public IActionResult Index()
        {
            return View();
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

        public async Task<IActionResult> Under()
        {
            var getUnder = new GetUndergraduate();
            var under = await getUnder.GetUnderGradDegrees();
            var underViewModel = new UndergradViewModel()
            {
                UnderGrads = under,
                Title = "Undergraduate Programs"
            };
            return View(underViewModel);
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
