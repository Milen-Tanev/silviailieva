namespace SilviaIlieva.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SilviaIlieva.Data.Models;

    public class SilviaIlievaDbContext : IdentityDbContext<User, Role, string>
    {
        public SilviaIlievaDbContext(DbContextOptions<SilviaIlievaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Illustration> Illustrations { get; set; }

        public DbSet<Graphic> Graphics { get; set; }

        public DbSet<Motion> Motions { get; set; }

        public DbSet<Painting> Paintings { get; set; }
    }
}
