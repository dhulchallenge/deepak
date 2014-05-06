using CQRS.CarRental.Infrastructure.Commands;
using CQRS.CarRental.Infrastructure.Domain;
using CQRS.CarRental.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Infrastructure
{
    public class ChangeBookingCommandHandler : ICommandHandler<ChangeBookingCommand>
    {

        private List<Event> events;
        public ChangeBookingCommandHandler()
        {
           
            events = new List<Event>();
        }
        public void Execute(ChangeBookingCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }
            string eventMode = string.Empty;
            var carRentalRepository = RepositoryFactory.Current.Get<ICarRentalRepository>();
            var carRentalDetail1 = carRentalRepository.GetAll();
            var carRentalDetail = carRentalDetail1.Where(s => s.RentalId == command.RentalId).FirstOrDefault();
            if (carRentalDetail.CarRentalEndDate != command.CarRentalEndDate)
           {
               eventMode = "DE";
               var aggregate = new CarRentalDetail(command.RentalId, command.CarRentalEndDate,"E");
               carRentalDetail.CarRentalEndDate = command.CarRentalEndDate;
               publishEvent(aggregate, eventMode);
           }
            if (carRentalDetail.CarRentalStartDate != command.CarRentalStartDate)
           {
               eventMode = "DS";
               var aggregate = new CarRentalDetail(command.RentalId, command.CarRentalStartDate,"S" );
               carRentalDetail.CarRentalStartDate = command.CarRentalStartDate;
               publishEvent(aggregate, eventMode);
           }
            if (carRentalDetail.Status != command.Status)
           {
               eventMode = "SC";
               var aggregate = new CarRentalDetail(command.RentalId, command.Status);
               carRentalDetail.Status = command.Status;
               publishEvent(aggregate, eventMode);

           }



            carRentalRepository.Attach(carRentalDetail);
            carRentalRepository.UnitOfWork.SaveChanges();
      
           
        }
        private void publishEvent(AggregateRoot  aggregateRoot,string Mode)
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

               if (Mode == "DE")
               {
                   eventBus.Publish<BookingToDateChangedEvent>(desEvent);
               }
               else if (Mode == "DS")
               {
                   eventBus.Publish<BookingFromDateChangedEvent>(desEvent);
               }
               else if (Mode == "SC")
               {
                   eventBus.Publish<BookingCanceledEvent>(desEvent);
               }
           }

       }


    }
}
