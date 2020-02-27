namespace SilviaIlieva.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using SilviaIlieva.Data.Models;

    public class SilviaIlievaDbContext : IdentityDbContext<User, Role, string>
    {
        private readonly IConfiguration configuration;

        public SilviaIlievaDbContext(DbContextOptions<SilviaIlievaDbContext> options, IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<Illustration> Illustrations { get; set; }

        public DbSet<Graphic> Graphics { get; set; }

        public DbSet<Motion> Motions { get; set; }

        public DbSet<Painting> Paintings { get; set; }

        public DbSet<UtilityData> UtilityData { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            DataInitializer.SeedUtilityData(builder);
            DataInitializer.SeedAdministrator(builder, this.configuration);
            base.OnModelCreating(builder);
        }
    }
}
