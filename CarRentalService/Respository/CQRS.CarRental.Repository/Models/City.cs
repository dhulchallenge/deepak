using System;
using System.Collections.Generic;

namespace CQRS.CarRental.Repository.Foundation.Models
{
    public partial class City
    {
        public City()
        {
            this.Locations = new List<Location>();
        }

        public System.Guid CityId { get; set; }
        public string CityName { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}
