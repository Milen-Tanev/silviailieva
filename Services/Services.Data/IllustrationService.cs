﻿namespace SilviaIlieva.Services.Data
{
    using Contracts;
    using global::AutoMapper;
    using SilviaIlieva.Data.Common.Contracts;
    using SilviaIlieva.Data.Models;
    using SilviaIlieva.Services.Data.Abstract;

    public class IllustrationService : AbstractService<Illustration>, IIllustrationService
    {
        public IllustrationService(IDbRepository<Illustration> dbRepository, ITransactionManager transactionManager, IMapper mapper)
            : base(dbRepository, transactionManager, mapper)
        {            
        }

        protected override Illustration CreateEntity(string fileName, string imageName)
        {
            return new Illustration()
            {
                ImageUrl = fileName,
                Name = imageName
            };
        }
    }
}
