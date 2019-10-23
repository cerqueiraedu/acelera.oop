using Acelera.OO.CarRental.Entities.RentalSelections.Interfaces;

namespace Acelera.OO.CarRental.Entities.RentalSelections
{
    public class RentalSelection : IRentalSelection
    {
        public IAvailableRentalSelection AvailableRentalSelection { get; }

        public RentalSelection(IAvailableRentalSelection availableRentalSelection) => AvailableRentalSelection = availableRentalSelection;

        public IRental VehiculeRental(decimal traveledMetricUnits, int rentalDaysPeriod)
            => new Rental(
                AvailableRentalSelection.GetCarAvailableRentals(), 
                AvailableRentalSelection.GetCarRentalAvailableFeatures(), 
                traveledMetricUnits, 
                rentalDaysPeriod);

        public IRental MotorHomeRental(decimal traveledMetricUnits, int rentalDaysPeriod)
            => new Rental(
                AvailableRentalSelection.GetMotorHomeAvailableRentals(), 
                AvailableRentalSelection.GetMotorHomeRentalAvailableFeatures(), 
                traveledMetricUnits, 
                rentalDaysPeriod);
    }
}