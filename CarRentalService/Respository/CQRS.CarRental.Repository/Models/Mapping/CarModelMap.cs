using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace CQRS.CarRental.Repository.Foundation.Models.Mapping
{
    public class CarModelMap : EntityTypeConfiguration<CarModel>
    {
        public CarModelMap()
        {
            // Primary Key
            this.HasKey(t => t.CarModelId);

            // Properties
            this.Property(t => t.ModelName)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("CarModels");
            this.Property(t => t.CarModelId).HasColumnName("CarModelId");
            this.Property(t => t.CarManufacturerId).HasColumnName("CarManufacturerId");
            this.Property(t => t.ModelName).HasColumnName("ModelName");
            this.Property(t => t.RentalTariff).HasColumnName("RentalTariff");
            this.Property(t => t.AvailabilityStartDate).HasColumnName("AvailabilityStartDate");
            this.Property(t => t.AvailabilityEndDate).HasColumnName("AvailabilityEndDate");
            this.Property(t => t.Status).HasColumnName("Status");

            // Relationships
            this.HasOptional(t => t.CarManufacturerDetail)
                .WithMany(t => t.CarModels)
                .HasForeignKey(d => d.CarManufacturerId);

        }
    }
}
