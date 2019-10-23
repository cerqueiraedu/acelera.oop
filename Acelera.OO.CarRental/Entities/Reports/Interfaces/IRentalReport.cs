
using System.Collections.Generic;
using Acelera.OO.CarRental.Entities.RentalSelections.Interfaces;

namespace Acelera.OO.CarRental.Entities.Reports.Interfaces
{
    public interface IRentalReport
    {
        decimal TotalEstimateDistanceFee { get; }

        IRentalReport CalculateAllRentalFees();
        string ExhibitSummary();
        IRentalReport With(IEnumerable<IRental> rentals);
    }
}