using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Infrastructure
{
  public  class BookingToDateChangedEvent : Event
    {
        public System.Guid RentalId { get; set; }
        public System.DateTime CarRentalEndDate { get; set; }
        public BookingToDateChangedEvent(Guid RentalId, System.DateTime CarRentalEndDate)
        {
            this.RentalId = RentalId;
            this.CarRentalEndDate = CarRentalEndDate;
        }
       
    }
}
