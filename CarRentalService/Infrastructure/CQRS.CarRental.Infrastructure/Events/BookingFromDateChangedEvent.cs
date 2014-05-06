using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Infrastructure
{
   public class BookingFromDateChangedEvent : Event
    {
        public System.Guid RentalId { get; set; }        
        public System.DateTime CarRentalStartDate { get; set; }

        public BookingFromDateChangedEvent(Guid RentalId, System.DateTime CarRentalStartDate)
        {
            this.RentalId = RentalId;
            this.CarRentalStartDate = CarRentalStartDate;
        }
    }
}
