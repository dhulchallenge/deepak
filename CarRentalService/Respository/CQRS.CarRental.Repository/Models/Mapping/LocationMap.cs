using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace CQRS.CarRental.Repository.Foundation.Models.Mapping
{
    public class LocationMap : EntityTypeConfiguration<Location>
    {
        public LocationMap()
        {
            // Primary Key
            this.HasKey(t => t.LocationId);

            // Properties
            this.Property(t => t.LocationName)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Location");
            this.Property(t => t.LocationId).HasColumnName("LocationId");
            this.Property(t => t.CityId).HasColumnName("CityId");
            this.Property(t => t.LocationName).HasColumnName("LocationName");

            // Relationships
            this.HasRequired(t => t.City)
                .WithMany(t => t.Locations)
                .HasForeignKey(d => d.CityId);

        }
    }
}
