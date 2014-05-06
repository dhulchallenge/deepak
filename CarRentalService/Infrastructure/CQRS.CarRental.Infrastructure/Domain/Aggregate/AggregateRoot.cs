using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Infrastructure.Domain
{
   public class AggregateRoot
    {
       public Guid Id { get; internal set; }
       private readonly List<Event> changes;

       protected void ApplyChange(Event @event)
       {
           ApplyChange(@event,true);
       }


       protected AggregateRoot()
       {
           changes = new List<Event>();
       }

       public IEnumerable<Event> GetUncommittedChanges()
       {
           return changes;
       }




       private void ApplyChange(Event @event, bool isNew)
       {
           dynamic d = this;

           d.Handle(Converter.ChangeTo(@event, @event.GetType()));
           if (isNew)
           {
               changes.Add(@event);
           }
       }      

    }
}
