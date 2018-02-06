using ConstructionDiary.BR.ConstructionSites.Interfaces;
using ConstructionDiary.BR.UserManagment;
using ConstructionDiary.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ConstructionDiary.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        IUserManagment userManagment;
        private readonly IWorkersService _workersService;

        public HomeController(IUserManagment userManagment, IWorkersService workersService)
        {
            this.userManagment = userManagment;
            _workersService = workersService;
        }

        public IActionResult Index(int? workerId)
        {
            var model = new TodaysTasksViewModel()
            {
                Tasks = _workersService.GetTodaysTasks(workerId),
                SelectedWorkerId = workerId,
            };
            return View(model);
        }
        [Authorize(Roles = "Manager")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Authorize(Roles = "ConstructionSiteManager, Manager")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public JsonResult CheckForPasswordReset()
        {

            return new JsonResult(userManagment.ShouldChangePassword());
        }
    }
}
