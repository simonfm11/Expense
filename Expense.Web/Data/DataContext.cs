using Expense.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Expense.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<TripEntity> Trips { get; set; }
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<CityEntity> Cities { get; set; }
        public DbSet<TripDetailsEntity> TripDetails { get; set; }
        public DbSet<ExpenseTypeEntity> ExpenseTypes { get; set; }
    }
    

}
