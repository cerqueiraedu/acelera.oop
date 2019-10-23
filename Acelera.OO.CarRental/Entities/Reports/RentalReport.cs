using System.Collections.Generic;
using System.Linq;
using Acelera.OO.CarRental.Entities.RentalSelections.Interfaces;
using Acelera.OO.CarRental.Entities.Reports.Interfaces;

namespace Acelera.OO.CarRental.Entities.Reports
{
    public class RentalReport : IRentalReport
    {
        protected readonly IExhibitRentalReport RentalReportFormatter;
        protected IEnumerable<IRental> Rentals;

        public decimal TotalEstimateDistanceFee { get; protected set; }

        public RentalReport(IExhibitRentalReport rentalReportFormatter)
        {
            RentalReportFormatter = rentalReportFormatter;
        }

        public IRentalReport With(IEnumerable<IRental> rentals)
        {
            Rentals = rentals;
            return this;
        }

        public IRentalReport CalculateAllRentalFees()
        {
            Rentals
                .ToList()
                .ForEach(rental =>
                {
                    rental
                        .EstimateRentalPeriodFee()
                        .EstimateTraveledDistanceFee()
                        .EstimatePurchasedFeaturesFee()
                        .EstimateTotalRental();
                });

            return this;
        }

        public string ExhibitSummary()
        {
            return RentalReportFormatter
                .Format(Rentals)
                .ToString();
        }
    }
}