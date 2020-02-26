namespace SilviaIlieva.Data.Common
{
    using Contracts;
    using Microsoft.EntityFrameworkCore;
    using Models.Contracts;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class DbRepository<TEntity> : IDbRepository<TEntity>
        where TEntity : class, IEntity, IDeletable
    {
        private readonly DbSet<TEntity> dbSet;

        public DbRepository(SilviaIlievaDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("The Db context cannot be null.");
            }

            this.dbSet = dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.dbSet.Where(e => !e.IsDeleted);
        }

        public IQueryable<TEntity> GetByID(int id)
        {
            return this.dbSet.Where(e => !e.IsDeleted).Where(e => e.Id == id);
        }

        public async Task Create(TEntity entity)
        {
            await this.dbSet.AddAsync(entity).ConfigureAwait(false);
        }

        public void Update(TEntity entity)
        {
            this.dbSet.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
        }

        public void HardDelete(TEntity entity)
        {
            this.dbSet.Remove(entity);
        }
    }
}
