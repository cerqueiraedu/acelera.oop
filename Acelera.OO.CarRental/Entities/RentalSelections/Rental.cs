using System.Collections.Generic;
using Acelera.OO.CarRental.Entities.RentalFeatures.Interfaces;
using Acelera.OO.CarRental.Entities.RentalFeatures.Types.Interfaces;
using Acelera.OO.CarRental.Entities.RentalSelections.Interfaces;
using Acelera.OO.CarRental.Entities.Vehicules.Interfaces;
using Acelera.OO.CarRental.Entities.Vehicules.Types.Interfaces;

namespace Acelera.OO.CarRental.Entities.RentalSelections
{
    public class Rental : IRental
    {
        public int RentalDaysPeriod { get; protected set; }
        public decimal TraveledMetricUnits { get; protected set; }
        public decimal CalculatedEstimateTraveledDistanceFee { get; protected set; }
        public decimal CalculatedRentalPeriodFee { get; protected set; }
        public decimal CalculatedPurchasedFeaturesFee { get; protected set; }
        public decimal CalculatedTotalRental { get; protected set; }

        protected readonly IAvailableVehicules AvailableVehicules;
        protected readonly IAvailableRentalFeatures AvailableFeatures;

        public Rental(
            IAvailableVehicules availableVehicules,
            IAvailableRentalFeatures availableFeatures,
            decimal traveledMetricUnits,
            int rentalDaysPeriod)
        {
            TraveledMetricUnits = traveledMetricUnits;
            RentalDaysPeriod = rentalDaysPeriod;
            AvailableVehicules = availableVehicules;
            AvailableFeatures = availableFeatures;
        }

        public IRental EstimateRentalPeriodFee()
        {
            CalculatedRentalPeriodFee = AvailableVehicules.GetRentalVehicule().FeePerDay * RentalDaysPeriod;
            return this;
        }

        public IRental EstimateTraveledDistanceFee()
        {
            CalculatedEstimateTraveledDistanceFee = AvailableVehicules.GetRentalVehicule().FeePerTraveledMetricUnit * TraveledMetricUnits;
            return this;
        }


        public IRental EstimatePurchasedFeaturesFee()
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

        public IList<IRentalFeature> GetPurchasedFeatures() => AvailableFeatures.GetPurchasedFeatures();

        public IRental RentVehicule<T>() where T : IVehicule
        {
            AvailableVehicules.RentVehicule<T>();
            return this;
        }

        public virtual IVehicule GetRentalVehicule() => AvailableVehicules.GetRentalVehicule();


    }
}