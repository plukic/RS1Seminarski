using ConstructionDiary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ConstructionDiary.BR;
using System.Diagnostics;
using ConstructionDiary.Helper;

namespace ConstructionDiary.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }
        [Authorization(false,false,false)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
    }
}
