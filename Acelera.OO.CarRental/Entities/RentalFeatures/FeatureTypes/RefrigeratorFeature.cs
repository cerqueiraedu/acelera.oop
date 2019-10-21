using CarRental.Entities.RentalFeatures.FeatureTypes.Interfaces;

namespace CarRental.Entities.RentalFeatures.FeatureTypes
{
    public class RefrigeratorFeature : IRentalFeature
    {
        public decimal Fee { get; protected set; }

        public RefrigeratorFeature(decimal fee)
        {
            Fee = fee;
        }

        public override string ToString()
        {
            return "Geladeira";
        }
    }
}