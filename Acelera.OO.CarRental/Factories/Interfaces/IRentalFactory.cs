using CarRental.RentalTypes.Abstractions;

namespace CarRental.Factories.Interfaces
{
    public interface IRentalFactory
    {
        IRental BuildMotorHomeRental(decimal traveledMetricUnits, int rentalDaysPeriod);
        IRental BuildVehiculeRental(decimal traveledMetricUnits, int rentalDaysPeriod);
    }
}