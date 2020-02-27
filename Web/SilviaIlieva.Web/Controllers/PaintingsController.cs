namespace SilviaIlieva.Web.Controllers
{
    using SilviaIlieva.Data.Models;
    using SilviaIlieva.Services.Data.Contracts;

    public class PaintingsController : DesignController<Painting>
    {
        public PaintingsController(IPaintingService paintingService)
            : base(paintingService)
        {
        }
    }
}