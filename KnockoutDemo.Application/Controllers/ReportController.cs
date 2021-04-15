using Microsoft.AspNetCore.Mvc;

namespace KnockoutDemo.Application.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
