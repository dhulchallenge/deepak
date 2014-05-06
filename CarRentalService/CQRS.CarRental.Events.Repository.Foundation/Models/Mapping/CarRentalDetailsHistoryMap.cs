using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CQRS.CarRental.Events.Repository.Foundation.Models.Mapping
{
    public class CarRentalDetailsHistoryMap : EntityTypeConfiguration<CarRentalDetailsHistory>
    {
        public CarRentalDetailsHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.HistoryId);

            // Properties
            this.Property(t => t.Status)
                .HasMaxLength(100);

            this.Property(t => t.DriverName)
                .HasMaxLength(50);

            this.Property(t => t.LicenseneNumber)
                .HasMaxLength(50);

            this.Property(t => t.EmailId)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CarRentalDetailsHistory");
            this.Property(t => t.HistoryId).HasColumnName("HistoryId");
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
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
        }
    }
}
