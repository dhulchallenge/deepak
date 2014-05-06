using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using CQRS.CarRental.Events.Repository.Foundation.Models.Mapping;

namespace CQRS.CarRental.Events.Repository.Foundation.Models
{
    public partial class CarRentalHistoryDatabaseContext : DbContext
    {
        static CarRentalHistoryDatabaseContext()
        {
            Database.SetInitializer<CarRentalHistoryDatabaseContext>(null);
        }

        public CarRentalHistoryDatabaseContext()
            : base("Name=CarRentalHistoryDatabaseContext")
        {
        }

        public DbSet<CarRentalDetailsHistory> CarRentalDetailsHistories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CarRentalDetailsHistoryMap());
        }
    }
}
