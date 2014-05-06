using System;
using System.Collections.Generic;

namespace CQRS.CarRental.Repository.Foundation.Models
{
    public partial class CarManufacturerDetail
    {
        public CarManufacturerDetail()
        {
            this.CarModels = new List<CarModel>();
        }

        public System.Guid CarManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public virtual ICollection<CarModel> CarModels { get; set; }
    }
}
