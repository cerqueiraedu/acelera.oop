using System.Collections.Generic;
using Acelera.OO.CarRental.Entities.RentalSelections.Interfaces;

namespace Acelera.OO.CarRental.Entities.Reports.Interfaces
{
    public interface IExhibitRentalReport
    {
        IExhibitRentalReport Format(IEnumerable<IRental> Rentals);
    }
}