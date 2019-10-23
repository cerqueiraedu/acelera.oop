using System.Collections.Generic;
using Acelera.OO.CarRental.Entities.RentalFeatures.Types.Interfaces;
using Acelera.OO.CarRental.Entities.Vehicules.Types.Interfaces;

namespace Acelera.OO.CarRental.Entities.RentalSelections.Interfaces
{
    public interface IRental
    {
        int RentalDaysPeriod { get; }
        decimal TraveledMetricUnits { get; }
        decimal CalculatedEstimateTraveledDistanceFee { get; }
        decimal CalculatedRentalPeriodFee { get; }
        decimal CalculatedPurchasedFeaturesFee { get; }
        decimal CalculatedTotalRental { get; }

        IRental EstimatePurchasedFeaturesFee();
        IRental EstimateRentalPeriodFee();
        IRental EstimateTotalRental();
        IRental EstimateTraveledDistanceFee();
        IList<IRentalFeature> GetPurchasedFeatures();
        IRental RemoveFeature<T>() where T : IRentalFeature;
        IRental AddFeature<T>() where T : IRentalFeature;
        IRental RentVehicule<T>() where T : IVehicule;
        IVehicule GetRentalVehicule();
    }
}