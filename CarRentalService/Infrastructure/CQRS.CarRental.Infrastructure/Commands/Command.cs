using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Infrastructure
{
    [Serializable]
    public class Command : ICommand
    {
        public Guid Id { get; private set; }     
        public Command(Guid id)
        {
            Id = id;         
        }
    }
}
