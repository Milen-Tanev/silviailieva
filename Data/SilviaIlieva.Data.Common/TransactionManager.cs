namespace SilviaIlieva.Data.Common
{
    using Contracts;
    using Microsoft.EntityFrameworkCore.Storage;
    using System;
    using System.Threading.Tasks;

    public class TransactionManager : ITransactionManager
    {
        private readonly SilviaIlievaDbContext dbContext;

        public TransactionManager(SilviaIlievaDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException("The Db context cannot be null.");
        }

        public IDbContextTransaction BeginTransaction()
        {
            return this.dbContext.Database.BeginTransaction();
        }

        public async Task Commit(IDbContextTransaction transaction)
        {
            await this.dbContext.SaveChangesAsync().ConfigureAwait(false);
            await transaction.CommitAsync().ConfigureAwait(false);
        }
    }
}
