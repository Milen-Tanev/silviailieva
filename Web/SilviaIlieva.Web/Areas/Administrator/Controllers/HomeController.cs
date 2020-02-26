namespace SilviaIlieva.Web.Areas.Administrator.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Area("Administrator")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}