using System;
using System.Collections.Generic;

namespace CQRS.CarRental.Repository.Foundation.Models
{
    public partial class CarModel
    {
        public CarModel()
        {
            this.CarRentalDetails = new List<CarRentalDetail>();
        }

        public System.Guid CarModelId { get; set; }
        public Nullable<System.Guid> CarManufacturerId { get; set; }
        public string ModelName { get; set; }
        public Nullable<int> RentalTariff { get; set; }
        public Nullable<System.DateTime> AvailabilityStartDate { get; set; }
        public Nullable<System.DateTime> AvailabilityEndDate { get; set; }
        public Nullable<bool> Status { get; set; }
        public virtual CarManufacturerDetail CarManufacturerDetail { get; set; }
        public virtual ICollection<CarRentalDetail> CarRentalDetails { get; set; }
    }
}
