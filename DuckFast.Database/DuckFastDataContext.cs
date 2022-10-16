using DuckFast.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace DuckFast.Database
{
    public class DuckFastDataContext : IdentityDbContext<UserAccount>
    {
        public DbSet<Article>? Articles { get; set; }
        public DbSet<UserAccount>? UserAccounts { get; set; }
        public DbSet<Category>? Categories { get; set; }

        public DuckFastDataContext(): base() { }

        public DuckFastDataContext(DbContextOptions<DuckFastDataContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=db;Database=duckfast_data;Username=postgres;Password=postgres");

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseNpgsql("Host=localhost;Database=duckfast_data;Username=postgres;Password=postgres");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName!.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName[6..]);
                }
            }

            modelBuilder.Entity<Article>().Property(x => x.Id).UseIdentityAlwaysColumn();
            modelBuilder.Entity<Category>().Property(x => x.Id).UseIdentityAlwaysColumn();
        }
    }
}
