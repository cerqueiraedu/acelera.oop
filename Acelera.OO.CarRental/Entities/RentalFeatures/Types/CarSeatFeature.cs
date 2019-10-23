using Acelera.OO.CarRental.Entities.RentalFeatures.Types.Interfaces;

namespace Acelera.OO.CarRental.Entities.RentalFeatures.Types
{
    public class CarSeatFeature : IRentalFeature
    {
        public decimal Fee { get; protected set; }

        public CarSeatFeature(decimal fee) => Fee = fee;

        public override string ToString() => "Cadeirinha";
    }
}