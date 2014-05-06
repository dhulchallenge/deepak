using System;
using System.Collections.Generic;

namespace CQRS.CarRental.Repository.Foundation.Models
{
    public partial class Location
    {
        public Location()
        {
            this.CarRentalDetails = new List<CarRentalDetail>();
        }

        public System.Guid LocationId { get; set; }
        public System.Guid CityId { get; set; }
        public string LocationName { get; set; }
        public virtual ICollection<CarRentalDetail> CarRentalDetails { get; set; }
        public virtual City City { get; set; }
    }
}
