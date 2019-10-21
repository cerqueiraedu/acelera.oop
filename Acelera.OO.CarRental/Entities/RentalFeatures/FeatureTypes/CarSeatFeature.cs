using CarRental.Entities.RentalFeatures.FeatureTypes.Interfaces;

namespace CarRental.Entities.RentalFeatures.FeatureTypes
{
    public class CarSeatFeature : IRentalFeature
    {
        public decimal Fee { get; protected set; }

        public CarSeatFeature(decimal fee)
        {
            Fee = fee;
        }

        public override string ToString()
        {
            return "Cadeirinha";
        }
    }
}