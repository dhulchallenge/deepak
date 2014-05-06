using System;
using System.Collections.Generic;

namespace CQRS.CarRental.Events.Repository.Foundation.Models
{
    public partial class CarRentalDetailsHistory
    {
        public int HistoryId { get; set; }
        public System.Guid RentalId { get; set; }
        public Nullable<System.Guid> CarModelId { get; set; }
        public Nullable<System.DateTime> CarRentalStartDate { get; set; }
        public Nullable<System.DateTime> CarRentalEndDate { get; set; }
        public Nullable<System.Guid> LocationId { get; set; }
        public string Status { get; set; }
        public Nullable<int> TotalCost { get; set; }
        public string DriverName { get; set; }
        public string LicenseneNumber { get; set; }
        public Nullable<int> ContactNumber { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    }
}
