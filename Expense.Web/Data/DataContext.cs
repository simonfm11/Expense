
using Expense.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Expense.Web.Data
{
    public class DataContext : IdentityDbContext<UserEntity>
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TripEntity>()
                .HasIndex(t => t.Id)
                .IsUnique();
        }

        public DbSet<TripEntity> Trips { get; set; }
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<CityEntity> Cities { get; set; }
        public DbSet<TripDetailsEntity> TripDetails { get; set; }
        public DbSet<ExpenseTypeEntity> ExpenseTypes { get; set; }
    }
}