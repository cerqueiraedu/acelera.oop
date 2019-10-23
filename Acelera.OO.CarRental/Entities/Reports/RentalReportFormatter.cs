
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Acelera.OO.CarRental.Entities.RentalSelections.Interfaces;
using Acelera.OO.CarRental.Entities.Reports.Interfaces;

namespace Acelera.OO.CarRental.Entities.Reports
{
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
            Rentals
                .ToList()
                .ForEach(rental =>
                {

                    _builder.AppendLine($"Tipo do Carro: {rental.GetRentalVehicule().ToString()}");
                    _builder.AppendLine($"Quantidade de diárias: {rental.RentalDaysPeriod.ToString()}");
                    _builder.AppendLine($"Valor total das diárias: {rental.CalculatedRentalPeriodFee.ToString("C", _cultureInfo)}");
                    _builder.AppendLine($"Estimativa de quilometragem: {rental.CalculatedEstimateTraveledDistanceFee.ToString("C", _cultureInfo)}");

                    _builder.AppendLine("Valores de todos os adicionais: ");

                    rental.GetPurchasedFeatures().ToList().ForEach(feature =>
                    {
                        _builder.AppendLine($"{feature.ToString()}: {feature.Fee.ToString("C", _cultureInfo)}");
                    });

                    _builder.AppendLine($"Valor total do aluguel: {rental.CalculatedTotalRental.ToString("C", _cultureInfo)}");
                });

            return this;
        }

        public override string ToString() => _builder.ToString();
    }
}