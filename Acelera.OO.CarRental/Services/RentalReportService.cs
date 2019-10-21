using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using CarRental.RentalTypes.Abstractions;

namespace CarRental.Services
{
    public interface IExhibitRentalReport
    {
        IExhibitRentalReport Format(IEnumerable<IRental> Rentals);
    }

    public class RentalReportFormatter : IExhibitRentalReport
    {
        private readonly StringBuilder _builder;
        private readonly CultureInfo _cultureInfo;

        public RentalReportFormatter(CultureInfo cultureInfo)
        {
            _cultureInfo = cultureInfo;
            _builder = new StringBuilder();
        }
        
        public IExhibitRentalReport Format(IEnumerable<IRental> Rentals)
        {
            Rentals.ToList().ForEach(rental => {

                _builder.AppendLine($"Tipo do Carro: {rental.ToString()}");  
                _builder.AppendLine($"Quantidade de diárias: {rental.RentalDaysPeriod.ToString()}");
                _builder.AppendLine($"Valor total das diárias: {rental.CalculatedRentalPeriodFee.ToString("C", _cultureInfo)}");
                _builder.AppendLine($"Estimativa de quilometragem: {rental.CalculatedEstimateTraveledDistanceFee.ToString("C", _cultureInfo)}"); 

                _builder.AppendLine("Valores de todos os adicionais: ");

                rental.GetPurchasedFeatures().ToList().ForEach(feature => {
                    _builder.AppendLine($"{feature.ToString()}: {feature.Fee.ToString("C", _cultureInfo)}");
                });    

                _builder.AppendLine($"Valor total do aluguel: {rental.CalculatedTotalRental.ToString("C", _cultureInfo)}");                           
            });

            return this;
        }

        public override string ToString()
        {
            return _builder.ToString();
        }
    }

    public interface IRentalReportService
    {
        decimal TotalEstimateDistanceFee { get; }

        RentalReportService CalculateAllRentalFees();
        string ExhibitSummary();
        RentalReportService With(IEnumerable<IRental> rentals);
    }

    public class RentalReportService : IRentalReportService
    {
        protected readonly IExhibitRentalReport RentalReportFormatter;
        protected IEnumerable<IRental> Rentals;

        public decimal TotalEstimateDistanceFee { get; protected set; }

        public RentalReportService(IExhibitRentalReport rentalReportFormatter)
        {
            RentalReportFormatter = rentalReportFormatter;
        }

        public RentalReportService With(IEnumerable<IRental> rentals)
        {
            Rentals = rentals;
            return this;
        }

        public RentalReportService CalculateAllRentalFees()
        {
            Rentals.ToList().ForEach(rental =>
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
            return RentalReportFormatter.Format(Rentals).ToString();
        }
    }
}