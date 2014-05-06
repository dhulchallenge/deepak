using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace CQRS.CarRental.Repository.Foundation.Models.Mapping
{
    public class CarManufacturerDetailMap : EntityTypeConfiguration<CarManufacturerDetail>
    {
        public CarManufacturerDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.CarManufacturerId);

            // Properties
            this.Property(t => t.ManufacturerName)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("CarManufacturerDetails");
            this.Property(t => t.CarManufacturerId).HasColumnName("CarManufacturerId");
            this.Property(t => t.ManufacturerName).HasColumnName("ManufacturerName");
        }
    }
}
