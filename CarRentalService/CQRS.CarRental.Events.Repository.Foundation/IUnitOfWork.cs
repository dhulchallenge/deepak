﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Events.Repository.Foundation
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}
