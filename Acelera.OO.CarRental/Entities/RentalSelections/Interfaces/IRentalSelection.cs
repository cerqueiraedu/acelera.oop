namespace Acelera.OO.CarRental.Entities.RentalSelections.Interfaces
{
    public interface IRentalSelection
    {
        IRental MotorHomeRental(decimal traveledMetricUnits, int rentalDaysPeriod);
        IRental VehiculeRental(decimal traveledMetricUnits, int rentalDaysPeriod);
    }
}