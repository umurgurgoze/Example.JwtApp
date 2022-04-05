using ExampleJwtApp.Back.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace ExampleJwtApp.Back.Persistance.Context
{
    public class ExampleJwtContext : DbContext
    {
        public ExampleJwtContext(DbContextOptions<ExampleJwtContext> options) : base(options)
        {

        }
        public DbSet<Product> Products => this.Set<Product>(); //[{get; set; yerine set zaten context.set olduğundan ve null durumlarına 
                                                               // çözüm amaçlı bu şekilde de yazılabilir.
        public DbSet<Category> Categories => this.Set<Category>();
        public DbSet<AppUser> AppUsers => this.Set<AppUser>();
        public DbSet<AppRole> AppRoles => this.Set<AppRole>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        internal Task<List<object>> AsNoTracking()
        {
            throw new NotImplementedException();
        }
    }
}
