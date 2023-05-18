using Clinic_Project.DataAccess.DbContext;
using Clinic_Project.Models;
using Clinic_Project.Models.Viewmodel;
using Clinic_Project.Services.LoginService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Clinic_Project.DataAccess.Repositories;
using Clinic_Project.Models.DoctorAgg;
using Clinic_Project.Models.TurnAgg;
using Serilog;

namespace Clinic_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TurnRepository _turnRepository;
        //private readonly Login _Login;
		public HomeController(ILogger<HomeController> logger, TurnRepository turnRepository)
		{
			//_Login = Login;
            _logger = logger;
            _turnRepository = turnRepository;
		}

        public IActionResult Index()
        {
            _logger.LogInformation(message:"This is Log Information");
            Log.Error(messageTemplate:"This is Error Log From Seq");
            Log.Information(messageTemplate: "This is Log Information from seq");
            _turnRepository.Add(new Turn()
            {
                DoctorId = 1,
                IsReserved = false,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now
            });

			return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel loginView)
        {
            
            //_Login.LoginChecker(loginView);
            if (CurrentUser.DoctorCheck)
            {
                return RedirectToAction("","",new {area="Doctor"});
            }
            else
            {
                return RedirectToAction("");
            }
           
        }
        [HttpGet]
        //public IActionResult Login()
        //{
            
        //    return View();

        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}