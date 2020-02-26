namespace Services.Data
{
    using global::AutoMapper;
    using Contracts;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using SilviaIlieva.Data.Common.Contracts;
    using SilviaIlieva.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
    using System.IO;
    using Microsoft.AspNetCore.Http;

    public class IllustrationsService : IIllustrationsService
    {
        private readonly IDbRepository<Illustration> illustrations;
        private readonly ITransactionManager transactionManager;
        private readonly IMapper mapper;

        public IllustrationsService(IDbRepository<Illustration> illustrations, ITransactionManager transactionManager, IMapper mapper)
        {
            this.illustrations = illustrations ?? throw new ArgumentNullException("Illustrations repository cannot be null.");
            this.transactionManager = transactionManager ?? throw new ArgumentNullException("Transaction manager cannot be null.");
            this.mapper = mapper ?? throw new ArgumentNullException("Automapper cannot be null.");
        }
        public async Task<IEnumerable<IllustrationModel>> GetAll()
        {
            var illustrations = await this.illustrations.GetAll().ToListAsync();
            var result = new List<IllustrationModel>();

            foreach (var item in illustrations)
            {
                result.Add(new IllustrationModel()
                {
                    Name = item.Name,
                    ImageUrl = item.ImageUrl
                });
            }

            return result;

            return await this.illustrations.GetAll()
                .Select(i => this.mapper.Map<IllustrationModel>(i))
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

            using var transaction = this.transactionManager.BeginTransaction();
            Illustration illustration = new Illustration()
            {
                ImageUrl = fileName,
                Name = imageName
            };
            await this.illustrations.Create(illustration).ConfigureAwait(false);
            await transactionManager.Commit(transaction).ConfigureAwait(false);
        }
    }
}
