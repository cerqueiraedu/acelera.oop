using System;
using System.Collections.Generic;
using System.Linq;
using CarRental.Entities.RentalFeatures.FeatureTypes.Interfaces;

namespace CarRental.Entities.RentalFeatures.Interfaces
{
    public interface IAvailableRentalFeatures
    {
        decimal EstimatePurchasedFeaturesFee();
        IReadOnlyList<IRentalFeature> GetFeatures();
        IList<IRentalFeature> GetPurchasedFeatures();
        IAvailableRentalFeatures AddFeature<T>() where T : IRentalFeature;
        IAvailableRentalFeatures RemoveFeature<T>() where T : IRentalFeature;
    }

    public abstract class AvailableRentalFeatures : IAvailableRentalFeatures
    {
        protected static Lazy<IReadOnlyList<IRentalFeature>> AvailableFeatures;
        protected readonly IList<IRentalFeature> PurchasedFeatures;

        public AvailableRentalFeatures()
        {
            PurchasedFeatures = new List<IRentalFeature>();
        }

        public IReadOnlyList<IRentalFeature> GetFeatures()
        {
            return AvailableFeatures.Value;
        }

        public IList<IRentalFeature> GetPurchasedFeatures()
        {
            return PurchasedFeatures;
        }

        public IAvailableRentalFeatures AddFeature<T>() where T : IRentalFeature
        {
            PurchasedFeatures.Add(AvailableFeatures.Value.OfType<T>().First());
            return this;
        }

        public IAvailableRentalFeatures RemoveFeature<T>() where T : IRentalFeature
        {
            PurchasedFeatures.Remove(PurchasedFeatures.OfType<T>().FirstOrDefault());
            return this;
        }

        public decimal EstimatePurchasedFeaturesFee()
        {
            return PurchasedFeatures.Sum(feature => feature.Fee);
        }
    }
}