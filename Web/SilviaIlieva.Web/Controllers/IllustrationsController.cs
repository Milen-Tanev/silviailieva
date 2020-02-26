namespace SilviaIlieva.Web.Controllers
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Contracts;
    using Services.Data.Models;

    public class IllustrationsController : Controller
    {
        private readonly IIllustrationsService illustrationsService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public IllustrationsController(IIllustrationsService illustrationsService, IWebHostEnvironment webHostEnvironment)
        {
            this.illustrationsService = illustrationsService ?? throw new ArgumentNullException("IllustrationsService cannot be null.");
            this.webHostEnvironment = webHostEnvironment ?? throw new ArgumentNullException("WebHostEnvironment cannot be null.");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = await this.illustrationsService.GetAll();
            return this.View(model);
        }

        [HttpGet]
        public IActionResult Save()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(string name, IFormFile image)
        {
            var savePath = Path.Combine(webHostEnvironment.WebRootPath, "images");
            await this.illustrationsService.Add(name, image, savePath);

            return this.View();
        }
    }
}
