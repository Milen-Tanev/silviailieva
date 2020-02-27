namespace SilviaIlieva.Web.Controllers
{
    using Services.Data.Contracts;
    using SilviaIlieva.Data.Models;

    public class IllustrationsController : DesignController<Illustration>
    {
        public IllustrationsController(IIllustrationService illustrationsService)
        : base(illustrationsService)
        {
        }

        //[HttpGet]
        //public IActionResult Save()
        //{
        //    return this.View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Save(string name, IFormFile image)
        //{
        //    var savePath = Path.Combine(webHostEnvironment.WebRootPath, "images");
        //    await this.illustrationsService.Add(name, image, savePath);

        //    return this.View();
        //}
    }
}
