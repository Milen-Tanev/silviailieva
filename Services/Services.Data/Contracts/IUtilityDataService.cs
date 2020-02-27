namespace SilviaIlieva.Services.Data.Contracts
{
    using Models;
    using System.Threading.Tasks;

    public interface IUtilityDataService
    {
        Task<UtilityDataModel> GetAboutData();
    }
}
