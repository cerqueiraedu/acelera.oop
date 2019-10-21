using System.Collections.Generic;
using CarRental.Entities.RentalFeatures.FeatureTypes.Interfaces;
using CarRental.Entities.RentalFeatures.Interfaces;

namespace CarRental.RentalTypes.Abstractions
{
    public interface IRental
    {
        decimal FeePerDay { get; }
        decimal FeePerTraveledMetricUnit { get; }
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
    }

    public abstract class Rental : IRental
    {
        public abstract decimal FeePerDay { get; }
        public abstract decimal FeePerTraveledMetricUnit { get; }
        public int RentalDaysPeriod { get; protected set; }
        public decimal TraveledMetricUnits { get; protected set; }
        public decimal CalculatedEstimateTraveledDistanceFee { get; protected set; }
        public decimal CalculatedRentalPeriodFee { get; protected set; }
        public decimal CalculatedPurchasedFeaturesFee { get; protected set; }
        public decimal CalculatedTotalRental { get; protected set; }
        protected readonly IAvailableRentalFeatures AvailableFeatures;

        public Rental(IAvailableRentalFeatures availableFeatures, decimal traveledMetricUnits, int rentalDaysPeriod)
        {
            TraveledMetricUnits = traveledMetricUnits;
            RentalDaysPeriod = rentalDaysPeriod;
            AvailableFeatures = availableFeatures;
        }

        public virtual IRental EstimateRentalPeriodFee()
        {
            CalculatedRentalPeriodFee = FeePerDay * RentalDaysPeriod;
            return this;
        }

        public virtual IRental EstimateTraveledDistanceFee()
        {
            CalculatedEstimateTraveledDistanceFee = FeePerTraveledMetricUnit * TraveledMetricUnits;
            return this;
        }


        public virtual IRental EstimatePurchasedFeaturesFee()
        {
            CalculatedPurchasedFeaturesFee = AvailableFeatures.EstimatePurchasedFeaturesFee();
            return this;
        }

        public virtual IRental EstimateTotalRental()
        {
            CalculatedTotalRental =
                CalculatedEstimateTraveledDistanceFee +
                CalculatedRentalPeriodFee +
                CalculatedPurchasedFeaturesFee;

            return this;
        }

        public virtual IList<IRentalFeature> GetPurchasedFeatures()
        {
            return AvailableFeatures.GetPurchasedFeatures();
        }

        public IRental AddFeature<T>() where T : IRentalFeature
        {
            AvailableFeatures.AddFeature<T>();
            return this;
        }

        public IRental RemoveFeature<T>() where T : IRentalFeature
        {
            AvailableFeatures.RemoveFeature<T>();
            return this;
        }
    }
}