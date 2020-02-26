namespace SilviaIlieva.Data.Common.Contracts
{
    using Microsoft.EntityFrameworkCore.Storage;
    using System.Threading.Tasks;

    public interface ITransactionManager
    {
        IDbContextTransaction BeginTransaction();

        Task Commit(IDbContextTransaction transaction);
    }
}
