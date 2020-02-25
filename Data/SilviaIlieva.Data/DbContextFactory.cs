namespace SilviaIlieva.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class DbContextFactory : IDesignTimeDbContextFactory<SilviaIlievaDbContext>
    {
        public SilviaIlievaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SilviaIlievaDbContext>();
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS01;Database=SilviaIlieva;Integrated Security=True;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new SilviaIlievaDbContext(optionsBuilder.Options);
        }
    }
}
