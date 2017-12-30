using ConstructionDiary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ConstructionDiary.BR;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using ConstructionDiary.BR.UserManagment.Implementation;
using ConstructionDiary.BR.UserManagment;

namespace ConstructionDiary.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        IUserManagment userManagment;

        public HomeController(IUserManagment userManagment)
        {
            this.userManagment = userManagment;
        }

        public IActionResult Index()
        {
            return View();
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
