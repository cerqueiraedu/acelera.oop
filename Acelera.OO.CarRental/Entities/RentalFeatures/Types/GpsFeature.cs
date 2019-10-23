using Acelera.OO.CarRental.Entities.RentalFeatures.Types.Interfaces;

namespace Acelera.OO.CarRental.Entities.RentalFeatures.Types
{
    public class GpsFeature : IRentalFeature
    {
        public decimal Fee { get; protected set; }

        public GpsFeature(decimal fee) => Fee = fee;

        public override string ToString() => "GPS";
    }
}