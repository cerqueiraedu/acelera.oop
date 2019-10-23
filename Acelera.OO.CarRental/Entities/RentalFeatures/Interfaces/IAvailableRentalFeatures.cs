using System.Collections.Generic;
using Acelera.OO.CarRental.Entities.RentalFeatures.Types.Interfaces;

namespace Acelera.OO.CarRental.Entities.RentalFeatures.Interfaces
{
    public interface IAvailableRentalFeatures
    {
        decimal EstimatePurchasedFeaturesFee();
        IReadOnlyList<IRentalFeature> Features { get; }

        IList<IRentalFeature> GetPurchasedFeatures();
        IAvailableRentalFeatures AddFeature<T>() where T : IRentalFeature;
        IAvailableRentalFeatures RemoveFeature<T>() where T : IRentalFeature;
    }
}