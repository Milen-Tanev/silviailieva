namespace SilviaIlieva.Services.Data
{
    using global::AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using SilviaIlieva.Data.Common.Contracts;
    using SilviaIlieva.Data.Models;
    using SilviaIlieva.Services.Data.Contracts;
    using SilviaIlieva.Services.Data.Models;
    using System;
    using System.Threading.Tasks;

    public class UtilityDataService : IUtilityDataService
    {
        private const string AboutPageName = "About";

        private readonly IDbRepository<UtilityData> dbRepository;
        private readonly IMapper mapper;

        public UtilityDataService(IDbRepository<UtilityData> dbRepository, IMapper mapper)
        {
            this.dbRepository = dbRepository ?? throw new ArgumentNullException("UtilityData repository cannot be null.");
            this.mapper = mapper ?? throw new ArgumentNullException("Automapper cannot be null.");
        }

        public async Task<UtilityDataModel> GetAboutData()
        {
            return this.mapper.Map<UtilityDataModel>(await this.dbRepository.GetAll().FirstOrDefaultAsync(ud => ud.Name == AboutPageName).ConfigureAwait(false));
        }
    }
}
