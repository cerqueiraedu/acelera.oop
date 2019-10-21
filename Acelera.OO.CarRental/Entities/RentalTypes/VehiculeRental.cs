using CarRental.Entities.RentalFeatures.Interfaces;
using CarRental.RentalTypes.Abstractions;

namespace CarRental.RentalTypes
{
    public class VehiculeRental : Rental
    {
        public override decimal FeePerDay { get => 50; }
        public override decimal FeePerTraveledMetricUnit { get => 0.5M; }

        public VehiculeRental(IAvailableRentalFeatures availableRentalFeatures, decimal traveledMetricUnits, int rentalDaysPeriod) 
        : base(
            availableRentalFeatures, 
            traveledMetricUnits, 
            rentalDaysPeriod)
        {

        }

        public override string ToString()
        {
            return "Carro";
        }  
    }
}