using System.Linq;
using CarRental.Entities.RentalFeatures.FeatureTypes;
using NUnit.Framework;
using Moq;
using CarRental.RentalTypes.Abstractions;
using CarRental.Services;
using CarRental.Factories.Interfaces;
using CarRental.Factories;
using System.Collections.Generic;
using System;
using System.Globalization;

namespace Acelera.OO.CarRental.Tests.Services
{
    [TestFixture]
    public class RentalReportServiceTests
    {
        IRentalReportService rentalReportService;
        IRentalFactory rentalFactory;
        
        [SetUp]
        public void Setup()
        {
            rentalReportService = new RentalReportService(new RentalReportFormatter(new CultureInfo("pt-BR")));
            rentalFactory = new RentalFactory();
        }

        [Test]
        public void ExhibitSummary_Tests()
        {
            const string expectedResult =   "Tipo do Carro: Motor Home\r\n" +
                                            "Quantidade de diárias: 2\r\n" +
                                            "Valor total das diárias: R$ 600,00\r\n" +
                                            "Estimativa de quilometragem: R$ 552,50\r\n" + 
                                            "Valores de todos os adicionais: \r\n" +
                                            "GPS: R$ 35,00\r\n" +
                                            "Geladeira: R$ 250,00\r\n" +
                                            "Valor total do aluguel: R$ 1.437,50\r\n";

            var rentals = new List<IRental>() {
                rentalFactory
                    .BuildMotorHomeRental(850, 2)
                    .AddFeature<GpsFeature>()
                    .AddFeature<RefrigeratorFeature>()
            };

            var summary = rentalReportService
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

            rentalReportService
                .With(rentals)
                .CalculateAllRentalFees();
            
            foreach(var rentalMock in rentalMocks)
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