using Microsoft.EntityFrameworkCore;
using Upd8.Data.Mapping;
using Upd8.Domain.Entities;

namespace Upd8.Data.Context
{
    public class Upd8Context : DbContext
    {
        public DbSet<Customer> Customer { get; set; }

        public Upd8Context() { }

        public Upd8Context(DbContextOptions<Upd8Context> options) : base(options)
        {
            Database.SetCommandTimeout(7);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=localhost,1433;Database=Upd8;User ID=sa;Password=@G18u03i1986");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Upd8Context).Assembly);

            modelBuilder.ApplyConfiguration(new CustomerMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
