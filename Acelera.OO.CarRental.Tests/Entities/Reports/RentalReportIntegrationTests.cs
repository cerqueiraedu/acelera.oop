using System.Linq;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Globalization;
using Acelera.OO.CarRental.Entities.RentalFeatures.Types;
using Acelera.OO.CarRental.Entities.RentalSelections;
using Acelera.OO.CarRental.Entities.Reports.Interfaces;
using Acelera.OO.CarRental.Entities.Reports;
using Acelera.OO.CarRental.Entities.Vehicules.Types;
using Acelera.OO.CarRental.Entities.RentalSelections.Interfaces;

namespace Acelera.OO.CarRental.Tests.Entities.Reports
{
    [TestFixture]
    public class RentalReportIntegrationTests
    {
        IRentalReport rentalReport;
        IRentalSelection rentalSelection;

        [SetUp]
        public void Setup()
        {
            rentalReport = new RentalReport(new RentalReportFormatter(new CultureInfo("pt-BR")));
            rentalSelection = new RentalSelection(new AvailableRentalSelection());
        }

        [Test]
        public void ExhibitSummary_Tests()
        {
            const string expectedResult = "Tipo do Carro: Motor Home\r\n" +
                                            "Quantidade de diárias: 2\r\n" +
                                            "Valor total das diárias: R$ 600,00\r\n" +
                                            "Estimativa de quilometragem: R$ 552,50\r\n" +
                                            "Valores de todos os adicionais: \r\n" +
                                            "GPS: R$ 35,00\r\n" +
                                            "Geladeira: R$ 250,00\r\n" +
                                            "Valor total do aluguel: R$ 1.437,50\r\n";

            var rentals = new List<IRental>() {
                rentalSelection
                    .MotorHomeRental(850, 2)
                    .RentVehicule<MotorHome>()
                    .AddFeature<GpsFeature>()
                    .AddFeature<RefrigeratorFeature>()
            };

            var summary = rentalReport
                .With(rentals)
                .CalculateAllRentalFees()
                .ExhibitSummary();

            Assert.AreEqual(expectedResult, summary);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        public void CalculateAllRentalFees_Tests(int expectedCallTimes)
        {
            var rentalMocks = Enumerable.Range(0, expectedCallTimes).Select(index => GenerateRentalMock()).ToList();
            var rentals = rentalMocks.Select(r => r.Object);

            rentalReport
                .With(rentals)
                .CalculateAllRentalFees();

            foreach (var rentalMock in rentalMocks)
            {
                rentalMock.Verify(x => x.EstimateRentalPeriodFee(), Times.Once);
                rentalMock.Verify(x => x.EstimateTraveledDistanceFee(), Times.Once);
                rentalMock.Verify(x => x.EstimatePurchasedFeaturesFee(), Times.Once);
                rentalMock.Verify(x => x.EstimateTotalRental(), Times.Once);
            }
        }

        private Mock<IRental> GenerateRentalMock()
        {
            var rentalMock = new Mock<IRental>();

            rentalMock.Setup(r => r.EstimateRentalPeriodFee()).Returns(rentalMock.Object);
            rentalMock.Setup(r => r.EstimateTraveledDistanceFee()).Returns(rentalMock.Object);
            rentalMock.Setup(r => r.EstimatePurchasedFeaturesFee()).Returns(rentalMock.Object);
            rentalMock.Setup(r => r.EstimateTotalRental()).Returns(rentalMock.Object);

            return rentalMock;
        }
    }
}