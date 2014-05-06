using CQRS.CarRental.Infrastructure.Events.TypeAdapter;
using CQRS.CarRental.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Infrastructure.EventHandlers
{
    public class BookingToDateChangedEventHandle:IEventHandler<BookingToDateChangedEvent>
    {




        public void Handle(BookingToDateChangedEvent @event)
        {
            var carRentalHistoryRepository = RepositoryEventFactory.Current.Get<ICarRentalHistoryRepository>();
            carRentalHistoryRepository.Add(CreateBookingEventAdapter.ToDateChange(@event));
            carRentalHistoryRepository.UnitOfWork.SaveChanges();
        }
    }
    
}
