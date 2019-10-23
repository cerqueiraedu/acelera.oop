using Acelera.OO.CarRental.Entities.RentalFeatures.Types.Interfaces;

namespace Acelera.OO.CarRental.Entities.RentalFeatures.Types
{
    public class RefrigeratorFeature : IRentalFeature
    {
        public decimal Fee { get; protected set; }

        public RefrigeratorFeature(decimal fee) => Fee = fee;

        public override string ToString() => "Geladeira";
    }
}