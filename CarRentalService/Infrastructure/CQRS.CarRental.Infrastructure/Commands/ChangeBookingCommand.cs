using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Infrastructure.Commands
{
    public class ChangeBookingCommand : Command
    {
        public System.Guid RentalId { get; set; }
        public System.Guid CarModelId { get; set; }
        public System.DateTime CarRentalStartDate { get; set; }
        public System.DateTime CarRentalEndDate { get; set; }
        public System.Guid LocationId { get; set; }
        public string Status { get; set; }
        public int TotalCost { get; set; }
        public string DriverName { get; set; }
        public string LicenseneNumber { get; set; }
        public int ContactNumber { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }

        public ChangeBookingCommand(Guid RentalId, System.Guid CarModelId,
            System.DateTime CarRentalEndDate, System.DateTime CarRentalStartDate, System.Guid LocationId,
            int TotalCost, string DriverName, string LicenseneNumber, int ContactNumber, string EmailId, string Address,string status)
            : base(RentalId)
        {
            this.RentalId = RentalId;
            this.CarModelId = CarModelId;
            this.CarRentalEndDate = CarRentalEndDate;
            this.CarRentalStartDate = CarRentalStartDate;
            this.LocationId = LocationId;
            this.TotalCost = TotalCost;
            this.DriverName = DriverName;
            this.LicenseneNumber = LicenseneNumber;
            this.ContactNumber = ContactNumber;
            this.EmailId = EmailId;
            this.Address = Address;
            this.Status = status;

        }


    }
}
