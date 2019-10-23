using System;
using System.Collections.Generic;
using System.Linq;
using Acelera.OO.CarRental.Entities.RentalFeatures.Interfaces;
using Acelera.OO.CarRental.Entities.RentalFeatures.Types.Interfaces;

namespace Acelera.OO.CarRental.Entities.RentalFeatures.Abstractions
{
    public abstract class AvailableRentalFeatures : IAvailableRentalFeatures
    {
        protected Lazy<IReadOnlyList<IRentalFeature>> AvailableFeatures;
        protected readonly IList<IRentalFeature> PurchasedFeatures;

        public AvailableRentalFeatures() => PurchasedFeatures = new List<IRentalFeature>();

        public IReadOnlyList<IRentalFeature> Features => AvailableFeatures.Value;

        public IList<IRentalFeature> GetPurchasedFeatures() => PurchasedFeatures;

        public IAvailableRentalFeatures AddFeature<T>() where T : IRentalFeature
        {
            var feature = AvailableFeatures.Value.OfType<T>().FirstOrDefault();

            if (feature == null)
                return this; // todo: should throw FeatureNotAvailableException

            PurchasedFeatures.Add(feature);
            return this;
        }

        public IAvailableRentalFeatures RemoveFeature<T>() where T : IRentalFeature
        {
            PurchasedFeatures.Remove(PurchasedFeatures.OfType<T>().FirstOrDefault());
            return this;
        }

        public decimal EstimatePurchasedFeaturesFee() => PurchasedFeatures.Sum(feature => feature.Fee);
    }
}