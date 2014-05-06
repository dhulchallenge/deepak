using CQRS.CarRental.Repository.Foundation.Models.Mapping;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace CQRS.CarRental.Repository.Foundation.Models
{
    public partial class CarRentalDatabaseContext : DbContext
    {
        static CarRentalDatabaseContext()
        {
            Database.SetInitializer<CarRentalDatabaseContext>(null);
        }

        public CarRentalDatabaseContext()
            : base("Name=CarRentalDatabaseContext")
        {
        }

        public DbSet<CarManufacturerDetail> CarManufacturerDetails { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarRentalDetail> CarRentalDetails { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CarManufacturerDetailMap());
            modelBuilder.Configurations.Add(new CarModelMap());
            modelBuilder.Configurations.Add(new CarRentalDetailMap());
            modelBuilder.Configurations.Add(new CityMap());
            modelBuilder.Configurations.Add(new LocationMap());
        }
    }
}
