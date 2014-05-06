using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace CQRS.CarRental.Repository.Foundation.Models.Mapping
{
    public class CarRentalDetailMap : EntityTypeConfiguration<CarRentalDetail>
    {
        public CarRentalDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.RentalId);

            // Properties
            this.Property(t => t.Status)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.DriverName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.LicenseneNumber)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.EmailId)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CarRentalDetails");
            this.Property(t => t.RentalId).HasColumnName("RentalId");
            this.Property(t => t.CarModelId).HasColumnName("CarModelId");
            this.Property(t => t.CarRentalStartDate).HasColumnName("CarRentalStartDate");
            this.Property(t => t.CarRentalEndDate).HasColumnName("CarRentalEndDate");
            this.Property(t => t.LocationId).HasColumnName("LocationId");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.TotalCost).HasColumnName("TotalCost");
            this.Property(t => t.DriverName).HasColumnName("DriverName");
            this.Property(t => t.LicenseneNumber).HasColumnName("LicenseneNumber");
            this.Property(t => t.ContactNumber).HasColumnName("ContactNumber");
            this.Property(t => t.EmailId).HasColumnName("EmailId");
            this.Property(t => t.Address).HasColumnName("Address");

            // Relationships
            this.HasRequired(t => t.CarModel)
                .WithMany(t => t.CarRentalDetails)
                .HasForeignKey(d => d.CarModelId);
            this.HasRequired(t => t.Location)
                .WithMany(t => t.CarRentalDetails)
                .HasForeignKey(d => d.LocationId);

        }
    }
}
