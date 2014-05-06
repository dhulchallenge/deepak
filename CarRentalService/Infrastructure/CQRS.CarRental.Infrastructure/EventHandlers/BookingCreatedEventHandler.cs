using CQRS.CarRental.Infrastructure.Events.TypeAdapter;
using CQRS.CarRental.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Infrastructure
{
    public class BookingCreatedEventHandler : IEventHandler<BookingCreatedEvent>
    {

       
        public void Handle(BookingCreatedEvent @event)
        {


            var carRentalHistoryRepository = RepositoryEventFactory.Current.Get<ICarRentalHistoryRepository>();
            carRentalHistoryRepository.Add(CreateBookingEventAdapter.changeType(@event));
            carRentalHistoryRepository.UnitOfWork.SaveChanges();
            
        }

    }
}
