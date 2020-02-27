namespace SilviaIlieva.Services.Data
{
    using Contracts;
    using global::AutoMapper;
    using SilviaIlieva.Data.Common.Contracts;
    using SilviaIlieva.Data.Models;
    using SilviaIlieva.Services.Data.Abstract;

    public class GraphicService : AbstractService<Graphic>, IGraphicService
    {
        public GraphicService(IDbRepository<Graphic> dbRepository, ITransactionManager transactionManager, IMapper mapper)
            : base(dbRepository, transactionManager, mapper)
        {
        }

        protected override Graphic CreateEntity(string fileName, string imageName)
        {
            return new Graphic()
            {
                ImageUrl = fileName,
                Name = imageName
            };
        }
    }
}
