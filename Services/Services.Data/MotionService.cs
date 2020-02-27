namespace SilviaIlieva.Services.Data
{
    using Contracts;
    using global::AutoMapper;
    using SilviaIlieva.Data.Common.Contracts;
    using SilviaIlieva.Data.Models;
    using SilviaIlieva.Services.Data.Abstract;

    public class MotionService : AbstractService<Motion>, IMotionService
    {
        public MotionService(IDbRepository<Motion> dbRepository, ITransactionManager transactionManager, IMapper mapper)
            : base(dbRepository, transactionManager, mapper)
        {            
        }

        protected override Motion CreateEntity(string fileName, string imageName)
        {
            return new Motion()
            {
                ImageUrl = fileName,
                Name = imageName
            };
        }
    }
}
