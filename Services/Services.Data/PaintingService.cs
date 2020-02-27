namespace SilviaIlieva.Services.Data
{
    using Contracts;
    using global::AutoMapper;
    using SilviaIlieva.Data.Common.Contracts;
    using SilviaIlieva.Data.Models;
    using SilviaIlieva.Services.Data.Abstract;

    public class PaintingService : AbstractService<Painting>, IPaintingService
    {
        public PaintingService(IDbRepository<Painting> dbRepository, ITransactionManager transactionManager, IMapper mapper)
            : base(dbRepository, transactionManager, mapper)
        {            
        }

        protected override Painting CreateEntity(string fileName, string imageName)
        {
            return new Painting()
            {
                ImageUrl = fileName,
                Name = imageName
            };
        }
    }
}
