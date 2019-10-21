using CarRental.Entities.RentalFeatures.Interfaces;
using CarRental.RentalTypes.Abstractions;

namespace CarRental.RentalTypes
{
    public class MotorHomeRental : Rental
    {
        public override decimal FeePerDay { get => 300; }
        public override decimal FeePerTraveledMetricUnit { get => 0.65M; }

        public MotorHomeRental(IAvailableRentalFeatures availableRentalFeatures, decimal traveledMetricUnits, int rentalDaysPeriod) 
        : base(
            availableRentalFeatures, 
            traveledMetricUnits, 
            rentalDaysPeriod)
        {

        }

        public override string ToString()
        {
            return "Motor Home";
        }   
    }
}