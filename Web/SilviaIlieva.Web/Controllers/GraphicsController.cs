namespace SilviaIlieva.Web.Controllers
{
    using SilviaIlieva.Data.Models;
    using SilviaIlieva.Services.Data.Contracts;

    public class GraphicsController : DesignController<Graphic>
    {
        public GraphicsController(IGraphicService graphicService)
            : base(graphicService)
        {
        }
    }
}