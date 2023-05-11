using Clinic_Project.DataAccess.DbContext;
using Clinic_Project.Models;
using Clinic_Project.Models.Viewmodel;
using Clinic_Project.Services.LoginService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Clinic_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Login _Login;
        public HomeController(ILogger<HomeController> logger, Login Login)
        {
            _Login = Login;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel loginView)
        {
            _Login.LoginChecker(loginView);
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
        public IActionResult Login()
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