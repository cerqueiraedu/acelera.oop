using CarRental.Entities.RentalFeatures;
using CarRental.Factories.Interfaces;
using CarRental.RentalTypes;
using CarRental.RentalTypes.Abstractions;

namespace CarRental.Factories
{
    public class RentalFactory : IRentalFactory
    {
        public IRental BuildVehiculeRental(decimal traveledMetricUnits, int rentalDaysPeriod)
        {
            return new VehiculeRental(new CarRentalAvailableFeatures(), traveledMetricUnits, rentalDaysPeriod);
        }

        public IRental BuildMotorHomeRental(decimal traveledMetricUnits, int rentalDaysPeriod)
        {
            return new MotorHomeRental(new MotorHomeRentalAvailableFeatures(), traveledMetricUnits, rentalDaysPeriod);
        }
    }
}