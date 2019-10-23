using Acelera.OO.CarRental.Entities.Vehicules.Types.Interfaces;

namespace Acelera.OO.CarRental.Entities.Vehicules.Types
{
    public class Car : IVehicule
    {
        public decimal FeePerDay { get => 50; }
        public decimal FeePerTraveledMetricUnit { get => 0.5M; }

        public override string ToString() => "Car";
    }
}