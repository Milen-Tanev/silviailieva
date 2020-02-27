namespace SilviaIlieva.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SilviaIlieva.Services.Data.Contracts;
    using System;
    using System.Threading.Tasks;

    public class AboutController : Controller
    {
        private readonly IUtilityDataService utilityDataService;

        public AboutController(IUtilityDataService utilityDataService)
        {
            this.utilityDataService = utilityDataService ?? throw new ArgumentNullException("UtilityData service cannot be null.");
        }

        [HttpGet]
        [AllowAnonymous]
        [ResponseCache(Duration = 60 * 60)]
        public async Task<IActionResult> Index()
        {
            var aboutData = await this.utilityDataService.GetAboutData();
            return View(aboutData);
        }
    }
}