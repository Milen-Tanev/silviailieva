namespace SilviaIlieva.Web.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Contracts;
    using SilviaIlieva.Data.Models.Contracts;

    public abstract class DesignController<T> : Controller
        where T : class, IEntity
    {
        protected readonly IAbstractService<T> DataServiceService;

        public DesignController(IAbstractService<T> illustrationsService)
        {
            this.DataServiceService = illustrationsService ?? throw new ArgumentNullException("IllustrationsService cannot be null.");
        }

        [HttpGet]
        [AllowAnonymous]
        [ResponseCache(Duration = 60 * 60)]
        public async Task<IActionResult> Index()
        {
            var model = await this.DataServiceService.GetAll();
            return this.View(model);
        }
    }
}