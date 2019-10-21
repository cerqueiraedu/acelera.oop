using CarRental.Entities.RentalFeatures.FeatureTypes.Interfaces;

namespace CarRental.Entities.RentalFeatures.FeatureTypes
{
    public class GpsFeature : IRentalFeature
    {
        public decimal Fee { get; protected set; }

        public GpsFeature(decimal fee)
        {
            Fee = fee;
        }

        public override string ToString()
        {
            return "GPS";
        }
    }
}