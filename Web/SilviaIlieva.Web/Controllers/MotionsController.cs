namespace SilviaIlieva.Web.Controllers
{
    using SilviaIlieva.Data.Models;
    using SilviaIlieva.Services.Data.Contracts;

    public class MotionsController : DesignController<Motion>
    {
        public MotionsController(IMotionService motionService)
            : base(motionService)
        {
        }
    }
}