namespace SilviaIlieva.Web.Controllers
{
    using AutoMapper.Configuration;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SilviaIlieva.Services.External.Contracts;
    using SilviaIlieva.Services.External.Models;
    using SilviaIlieva.Web.Models;
    using System;
    using System.Threading.Tasks;

    public class ContactsController : Controller
    {
        private readonly IEmailSender emailSender;

        public ContactsController(IEmailSender emailSender)
        {
            this.emailSender = emailSender ?? throw new ArgumentNullException("The Email sender cannot be null.");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(ContactViewModel contactViewModel)
        {
            // Send message
            var message = new EmailMessage(new string[] { "mil3ntanev@abv.bg" }, contactViewModel.Name, $"Name: {contactViewModel.Name}\nMessage: {contactViewModel.Message}\nEmail: {contactViewModel.Email}");
            await this.emailSender.SendMessage(message);
            
            return this.View();
        }
    }
}