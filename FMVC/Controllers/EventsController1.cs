using Microsoft.AspNetCore.Mvc;

namespace FMVC.Controllers
{
    public class EventsController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
