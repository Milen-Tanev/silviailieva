namespace SilviaIlieva.Data.Common.Contracts
{
    using Models.Contracts;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IDbRepository<TEntity>
        where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetByID(int id);

        Task Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
