using Acelera.OO.CarRental.Entities.RentalFeatures;
using Acelera.OO.CarRental.Entities.RentalSelections.Interfaces;
using Acelera.OO.CarRental.Entities.Vehicules;

namespace Acelera.OO.CarRental.Entities.RentalSelections
{
    public class RentalSelection : IRentalSelection
    {
        public IRental VehiculeRental(decimal traveledMetricUnits, int rentalDaysPeriod)
            => new Rental(new CarAvailableRentals(), new CarRentalAvailableFeatures(), traveledMetricUnits, rentalDaysPeriod);

        public IRental MotorHomeRental(decimal traveledMetricUnits, int rentalDaysPeriod)
            => new Rental(new MotorHomeAvailableRentals(), new MotorHomeRentalAvailableFeatures(), traveledMetricUnits, rentalDaysPeriod);
    }
}