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
    public class MotorHomeRentalTests
    {
        IRental motorHomeRental;
        Mock<IAvailableRentalFeatures> availableRentalFeaturesMock; 

        [SetUp]
        public void Setup()
        {
            availableRentalFeaturesMock = new Mock<IAvailableRentalFeatures>();
        }

        [TestCase(0, 0)]
        [TestCase(100, 65)]
        [TestCase(850, 552.50)]
        public void EstimateTraveledDistanceFee_Tests(decimal traveledMetricUnits, decimal expectedFeePerTraveledMetricUnit)
        {
            motorHomeRental = new MotorHomeRental(availableRentalFeaturesMock.Object, traveledMetricUnits, 0);
            
            Assert.AreEqual(
                expectedFeePerTraveledMetricUnit, 
                motorHomeRental.EstimateTraveledDistanceFee().CalculatedEstimateTraveledDistanceFee);
        }

        [TestCase(0, 0)]
        [TestCase(1, 300)]
        [TestCase(2, 600)]
        [TestCase(3, 900)]
        public void EstimateRentalPeriodFee_Tests(int rentalDaysPeriod, decimal expectedRentalPeriodFee)
        {
            motorHomeRental = new MotorHomeRental(availableRentalFeaturesMock.Object, 0, rentalDaysPeriod);
            
            Assert.AreEqual(
                expectedRentalPeriodFee, 
                motorHomeRental.EstimateRentalPeriodFee().CalculatedRentalPeriodFee);
        }

        [Test]
        public void EstimatePurchasedFeaturesFee_Tests()
        {
            const decimal expectedResult = 99;

            availableRentalFeaturesMock.Setup(x => x.EstimatePurchasedFeaturesFee()).Returns(expectedResult);
            motorHomeRental = new MotorHomeRental(availableRentalFeaturesMock.Object, 0, 0);

            Assert.AreEqual(expectedResult, motorHomeRental.EstimatePurchasedFeaturesFee().CalculatedPurchasedFeaturesFee);
            availableRentalFeaturesMock.Verify(x => x.EstimatePurchasedFeaturesFee(), Times.Once);
        }

        [Test]
        public void EstimateTotalRental_Tests()
        {
            const decimal expectedEstimatePurchasedFeaturesFee = 99;
            const decimal expectedResult = 399.65M;
            
            availableRentalFeaturesMock.Setup(x => x.EstimatePurchasedFeaturesFee()).Returns(expectedEstimatePurchasedFeaturesFee);
            motorHomeRental = new MotorHomeRental(availableRentalFeaturesMock.Object, 1, 1);

            Assert.AreEqual(expectedResult, 
                motorHomeRental
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
            
            motorHomeRental = new MotorHomeRental(availableRentalFeaturesMock.Object, 0, 0);

            Assert.AreSame(expectedResult, motorHomeRental.GetPurchasedFeatures());
            availableRentalFeaturesMock.Verify(x => x.GetPurchasedFeatures(), Times.Once);
        }

        [Test]
        public void AddFeature_Tests()
        {
            availableRentalFeaturesMock.Setup(x => x.AddFeature<IRentalFeature>()).Returns(availableRentalFeaturesMock.Object);
            
            motorHomeRental = new MotorHomeRental(availableRentalFeaturesMock.Object, 0, 0);
            
            motorHomeRental.AddFeature<IRentalFeature>();
            availableRentalFeaturesMock.Verify(x => x.AddFeature<IRentalFeature>(), Times.Once);
        }

        [Test]
        public void RemoveFeature_Tests()
        {
            availableRentalFeaturesMock.Setup(x => x.RemoveFeature<IRentalFeature>()).Returns(availableRentalFeaturesMock.Object);
            
            motorHomeRental = new MotorHomeRental(availableRentalFeaturesMock.Object, 0, 0);
            
            motorHomeRental.RemoveFeature<IRentalFeature>();
            availableRentalFeaturesMock.Verify(x => x.RemoveFeature<IRentalFeature>(), Times.Once);
        }
    }
}