using Microsoft.AspNetCore.Mvc;

namespace KnockoutDemo.Application.Controllers
{
    public class TechnicalNotesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
