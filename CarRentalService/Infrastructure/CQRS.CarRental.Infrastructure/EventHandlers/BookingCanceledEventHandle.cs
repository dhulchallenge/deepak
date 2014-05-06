using CQRS.CarRental.Infrastructure.Events.TypeAdapter;
using CQRS.CarRental.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Infrastructure.EventHandlers
{
    public class BookingCanceledEventHandle : IEventHandler<BookingCanceledEvent>
    {


        public void Handle(BookingCanceledEvent @event)
        {


            var carRentalHistoryRepository = RepositoryEventFactory.Current.Get<ICarRentalHistoryRepository>();
            carRentalHistoryRepository.Add(CreateBookingEventAdapter.StatusChange(@event));
            carRentalHistoryRepository.UnitOfWork.SaveChanges();
            
        }

    }
   
}
