using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Infrastructure
{
   public class BookingCanceledEvent : Event
    {
        public System.Guid RentalId { get; set; }
        public string Status { get; set; }
       public BookingCanceledEvent(Guid RentalId, string Status)
        {
            this.RentalId = RentalId;
            this.Status = Status;
        }
    }
}
