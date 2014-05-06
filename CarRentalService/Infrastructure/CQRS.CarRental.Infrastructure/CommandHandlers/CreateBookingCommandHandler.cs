
using CQRS.CarRental.Infrastructure.Commands;
using CQRS.CarRental.Infrastructure.Domain;
using CQRS.CarRental.Infrastructure.Utils;
using CQRS.CarRental.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Infrastructure
{
    public class CreateBookingCommandHandler : ICommandHandler<CreateBookingCommand>
    {
      
       
        private List<Event> events;
        public CreateBookingCommandHandler()
        {
           

            events = new List<Event>();
        }
        public void Execute(CreateBookingCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }
            var aggregate = new CarRentalDetail(command.RentalId,command.CarModelId,command.CarRentalEndDate, command.CarRentalStartDate, command.LocationId,command.TotalCost,
            command.DriverName, command.LicenseneNumber, command.ContactNumber, command.EmailId, command.Address);
            aggregate.Status = "Active";
            publishEvent(aggregate);
            var carRentalRepository = RepositoryFactory.Current.Get<ICarRentalRepository>();
            carRentalRepository.Add(CreateBookingCommandAdapter.changeType(aggregate));
            carRentalRepository.UnitOfWork.SaveChanges();
      
           
        }
        private void publishEvent(AggregateRoot  aggregateRoot)
       {
        
           var eventBus = EventFactory.Current.Get<IEventBus>();
           var uncommittedChanges = aggregateRoot.GetUncommittedChanges();     
           foreach (var @event in uncommittedChanges)
           {             
               events.Add(@event);
           }
           foreach (var @event in uncommittedChanges)
           {
               var desEvent = Converter.ChangeTo(@event, @event.GetType());
               eventBus.Publish<BookingCreatedEvent>(desEvent);
           }




       }
    }
}
