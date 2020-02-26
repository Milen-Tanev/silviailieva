namespace Services.Data.AutoMapper
{
    using global::AutoMapper;
    using Services.Data.Models;
    using SilviaIlieva.Data.Models;

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            this.CreateMap<Illustration, IllustrationModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));
        }
    }
}
