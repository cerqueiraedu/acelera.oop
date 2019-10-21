using CarRental.RentalTypes.Abstractions;
using NUnit.Framework;
using CarRental.RentalTypes;
using Moq;
using CarRental.Entities.RentalFeatures.Interfaces;
using System.Collections.Generic;
using CarRental.Entities.RentalFeatures.FeatureTypes.Interfaces;

namespace Acelera.OO.CarRental.Tests.Entities.RentalTypes
{
    [TestFixture]
    public class VehiculeRentalTests
    {
        IRental carRental;
        Mock<IAvailableRentalFeatures> availableRentalFeaturesMock; 

        [SetUp]
        public void Setup()
        {
            availableRentalFeaturesMock = new Mock<IAvailableRentalFeatures>();
        }

        [TestCase(0, 0)]
        [TestCase(100, 50)]
        [TestCase(850, 425)]
        public void EstimateTraveledDistanceFee_Tests(decimal traveledMetricUnits, decimal expectedFeePerTraveledMetricUnit)
        {
            carRental = new VehiculeRental(availableRentalFeaturesMock.Object, traveledMetricUnits, 0);
            
            Assert.AreEqual(
                expectedFeePerTraveledMetricUnit, 
                carRental.EstimateTraveledDistanceFee().CalculatedEstimateTraveledDistanceFee);
        }

        [TestCase(0, 0)]
        [TestCase(1, 50)]
        [TestCase(2, 100)]
        [TestCase(3, 150)]
        public void EstimateRentalPeriodFee_Tests(int rentalDaysPeriod, decimal expectedRentalPeriodFee)
        {
            carRental = new VehiculeRental(availableRentalFeaturesMock.Object, 0, rentalDaysPeriod);
            
            Assert.AreEqual(
                expectedRentalPeriodFee, 
                carRental.EstimateRentalPeriodFee().CalculatedRentalPeriodFee);
        }

        [Test]
        public void EstimatePurchasedFeaturesFee_Tests()
        {
            const decimal expectedResult = 99;

            availableRentalFeaturesMock.Setup(x => x.EstimatePurchasedFeaturesFee()).Returns(expectedResult);
            carRental = new VehiculeRental(availableRentalFeaturesMock.Object, 0, 0);

            Assert.AreEqual(expectedResult, carRental.EstimatePurchasedFeaturesFee().CalculatedPurchasedFeaturesFee);
            availableRentalFeaturesMock.Verify(x => x.EstimatePurchasedFeaturesFee(), Times.Once);
        }

        [Test]
        public void EstimateTotalRental_Tests()
        {
            const decimal expectedEstimatePurchasedFeaturesFee = 99;
            const decimal expectedResult = 149.5M;
            
            availableRentalFeaturesMock.Setup(x => x.EstimatePurchasedFeaturesFee()).Returns(expectedEstimatePurchasedFeaturesFee);
            carRental = new VehiculeRental(availableRentalFeaturesMock.Object, 1, 1);

            Assert.AreEqual(expectedResult, 
                carRental
                .EstimateRentalPeriodFee()
                .EstimateTraveledDistanceFee()
                .EstimatePurchasedFeaturesFee()
                .EstimateTotalRental()
                .CalculatedTotalRental);

            availableRentalFeaturesMock.Verify(x => x.EstimatePurchasedFeaturesFee(), Times.Once);
        }

        [Test]
        public void GetPurchasedFeatures_Tests()
        {
            var expectedResult = new List<IRentalFeature>();
            availableRentalFeaturesMock.Setup(x => x.GetPurchasedFeatures()).Returns(expectedResult);
            
            carRental = new VehiculeRental(availableRentalFeaturesMock.Object, 0, 0);

            Assert.AreSame(expectedResult, carRental.GetPurchasedFeatures());
            availableRentalFeaturesMock.Verify(x => x.GetPurchasedFeatures(), Times.Once);
        }

        [Test]
        public void AddFeature_Tests()
        {
            availableRentalFeaturesMock.Setup(x => x.AddFeature<IRentalFeature>()).Returns(availableRentalFeaturesMock.Object);
            
            carRental = new VehiculeRental(availableRentalFeaturesMock.Object, 0, 0);
            
            carRental.AddFeature<IRentalFeature>();
            availableRentalFeaturesMock.Verify(x => x.AddFeature<IRentalFeature>(), Times.Once);
        }

        [Test]
        public void RemoveFeature_Tests()
        {
            availableRentalFeaturesMock.Setup(x => x.RemoveFeature<IRentalFeature>()).Returns(availableRentalFeaturesMock.Object);
            
            carRental = new VehiculeRental(availableRentalFeaturesMock.Object, 0, 0);
            
            carRental.RemoveFeature<IRentalFeature>();
            availableRentalFeaturesMock.Verify(x => x.RemoveFeature<IRentalFeature>(), Times.Once);
        }
    }
}