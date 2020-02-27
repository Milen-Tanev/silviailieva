namespace SilviaIlieva.Services.Data.AutoMapper
{
    using global::AutoMapper;
    using Models;
    using SilviaIlieva.Data.Models;

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            this.CreateMap<Illustration, DesignModel>();
            this.CreateMap<UtilityData, UtilityDataModel>();
        }
    }
}
