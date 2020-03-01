namespace SilviaIlieva.Services.External.Contracts
{
    using System.Threading.Tasks;
    using SilviaIlieva.Services.External.Models;

    public interface IEmailSender
    {
        Task SendMessage(EmailMessage message);
    }
}
