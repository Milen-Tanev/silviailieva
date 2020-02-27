namespace SilviaIlieva.Services.Data.Contracts
{
    using Microsoft.AspNetCore.Http;
    using SilviaIlieva.Data.Models.Contracts;
    using SilviaIlieva.Services.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAbstractService<TEntity>
        where TEntity : class, IEntity
    {
        Task<IEnumerable<DesignModel>> GetAll();

        Task Add(string imageName, IFormFile file, string savePath);
    }
}
