namespace SilviaIlieva.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SilviaIlieva.Web.Models;

    public class ContactsController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactViewModel contactViewModel)
        {
            return this.View();
        }
    }
}