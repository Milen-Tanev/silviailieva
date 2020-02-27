namespace SilviaIlieva.Services.Data.Abstract
{
    using global::AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using SilviaIlieva.Data.Common.Contracts;
    using SilviaIlieva.Data.Models.Contracts;
    using SilviaIlieva.Services.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public abstract class AbstractService<TEntity>
        where TEntity : class, IEntity
    {
        protected readonly IDbRepository<TEntity> DbRepository;
        private readonly ITransactionManager TransactionManager;
        private readonly IMapper Mapper;

        public AbstractService(IDbRepository<TEntity> dbRepository, ITransactionManager transactionManager, IMapper mapper)
        {
            this.DbRepository = dbRepository ?? throw new ArgumentNullException("DB repository cannot be null.");
            this.TransactionManager = transactionManager ?? throw new ArgumentNullException("Transaction manager cannot be null.");
            this.Mapper = mapper ?? throw new ArgumentNullException("Automapper cannot be null.");
        }

        public async Task<IEnumerable<DesignModel>> GetAll()
        {
            return await this.DbRepository.GetAll()
                .Select(i => this.Mapper.Map<DesignModel>(i))
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task Add(string imageName, IFormFile file, string savePath)
        {
            var extention = Path.GetExtension(file.FileName);
            var fileName = Path.Combine(savePath, imageName + extention);

            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                await file.CopyToAsync(stream).ConfigureAwait(false);
            }

            using var transaction = this.TransactionManager.BeginTransaction();
            var entity = this.CreateEntity(fileName, imageName);
            await this.DbRepository.Create(entity).ConfigureAwait(false);
            await TransactionManager.Commit(transaction).ConfigureAwait(false);
        }

        protected abstract TEntity CreateEntity(string fileName, string imageName);
    }
}
