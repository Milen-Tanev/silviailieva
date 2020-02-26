namespace Services.Data.Contracts
{
    using Microsoft.AspNetCore.Http;
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    public interface IIllustrationsService
    {
        Task<IEnumerable<IllustrationModel>> GetAll();

        Task Add(string imageName, IFormFile file, string savePath);
    }
}
