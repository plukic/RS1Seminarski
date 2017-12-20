using ConstructionDiary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ConstructionDiary.BR;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace ConstructionDiary.Controllers
{
    public class HomeController : Controller
    {
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
    }
}
