using CQRS.CarRental.Infrastructure.Events.TypeAdapter;
using CQRS.CarRental.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Infrastructure.EventHandlers
{
    public class BookingFromDateChangedEventHandler : IEventHandler<BookingFromDateChangedEvent>
    {


        public void Handle(BookingFromDateChangedEvent @event)
        {


            var carRentalHistoryRepository = RepositoryEventFactory.Current.Get<ICarRentalHistoryRepository>();
            carRentalHistoryRepository.Add(CreateBookingEventAdapter.FromDateChange(@event));
            carRentalHistoryRepository.UnitOfWork.SaveChanges();
            
        }

    }
}
