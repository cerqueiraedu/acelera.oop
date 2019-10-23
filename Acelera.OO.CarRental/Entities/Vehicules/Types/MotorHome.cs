using Acelera.OO.CarRental.Entities.Vehicules.Types.Interfaces;

namespace Acelera.OO.CarRental.Entities.Vehicules.Types
{
    public class MotorHome : IVehicule
    {
        public decimal FeePerDay { get => 300; }
        public decimal FeePerTraveledMetricUnit { get => 0.65M; }

        public override string ToString() => "Motor Home";
    }
}