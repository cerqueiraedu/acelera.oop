using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using Acelera.OO.CarRental.Entities.RentalFeatures.Types.Interfaces;
using Acelera.OO.CarRental.Entities.RentalFeatures.Interfaces;
using Acelera.OO.CarRental.Entities.Vehicules.Interfaces;
using Acelera.OO.CarRental.Entities.Vehicules.Types.Interfaces;
using Acelera.OO.CarRental.Entities.Vehicules.Types;
using Acelera.OO.CarRental.Entities.RentalSelections;
using Acelera.OO.CarRental.Entities.RentalSelections.Interfaces;

namespace Acelera.OO.CarRental.Tests.Entities.RentalSelections
{

    [TestFixture]
    public class RentalTests
    {
        IRental rental;
        Mock<IAvailableRentalFeatures> availableRentalFeaturesMock;
        Mock<IAvailableVehicules> availableVehiculesMock;
        Mock<IVehicule> vehiculeMock;

        [SetUp]
        public void Setup()
        {
            availableRentalFeaturesMock = new Mock<IAvailableRentalFeatures>();
            availableVehiculesMock = new Mock<IAvailableVehicules>();
            vehiculeMock = new Mock<IVehicule>();
        }

        [TestCase(0, 0)]
        [TestCase(100, 65)]
        [TestCase(850, 552.50)]
        public void MotorHome_EstimateTraveledDistanceFee_Tests(decimal traveledMetricUnits, decimal expectedFeePerTraveledMetricUnit)
        {
            rental = new Rental(availableVehiculesMock.Object, availableRentalFeaturesMock.Object, traveledMetricUnits, 0);
            availableVehiculesMock.Setup(v => v.GetRentalVehicule()).Returns(new MotorHome());

            Assert.AreEqual(
                expectedFeePerTraveledMetricUnit,
                rental.EstimateTraveledDistanceFee().CalculatedEstimateTraveledDistanceFee);

            availableVehiculesMock.Verify(v => v.GetRentalVehicule(), Times.Once);
        }

        [TestCase(0, 0)]
        [TestCase(100, 50)]
        [TestCase(850, 425)]
        public void Car_EstimateTraveledDistanceFee_Tests(decimal traveledMetricUnits, decimal expectedFeePerTraveledMetricUnit)
        {
            rental = new Rental(availableVehiculesMock.Object, availableRentalFeaturesMock.Object, traveledMetricUnits, 0);
            availableVehiculesMock.Setup(v => v.GetRentalVehicule()).Returns(new Car());

            Assert.AreEqual(
                expectedFeePerTraveledMetricUnit,
                rental.EstimateTraveledDistanceFee().CalculatedEstimateTraveledDistanceFee);

            availableVehiculesMock.Verify(v => v.GetRentalVehicule(), Times.Once);
        }

        [TestCase(0, 0)]
        [TestCase(1, 300)]
        [TestCase(2, 600)]
        [TestCase(3, 900)]
        public void MotorHome_EstimateRentalPeriodFee_Tests(int rentalDaysPeriod, decimal expectedRentalPeriodFee)
        {
            rental = new Rental(availableVehiculesMock.Object, availableRentalFeaturesMock.Object, 0, rentalDaysPeriod);
            availableVehiculesMock.Setup(v => v.GetRentalVehicule()).Returns(new MotorHome());

            Assert.AreEqual(
                expectedRentalPeriodFee,
                rental.EstimateRentalPeriodFee().CalculatedRentalPeriodFee);

            availableVehiculesMock.Verify(v => v.GetRentalVehicule(), Times.Once);
        }

        [TestCase(0, 0)]
        [TestCase(1, 50)]
        [TestCase(2, 100)]
        [TestCase(3, 150)]
        public void Car_EstimateRentalPeriodFee_Tests(int rentalDaysPeriod, decimal expectedRentalPeriodFee)
        {
            rental = new Rental(availableVehiculesMock.Object, availableRentalFeaturesMock.Object, 0, rentalDaysPeriod);
            availableVehiculesMock.Setup(v => v.GetRentalVehicule()).Returns(new Car());

            Assert.AreEqual(
                expectedRentalPeriodFee,
                rental.EstimateRentalPeriodFee()
                .CalculatedRentalPeriodFee);

            availableVehiculesMock.Verify(v => v.GetRentalVehicule(), Times.Once);
        }

        [Test]
        public void EstimatePurchasedFeaturesFee_Tests()
        {
            const decimal expectedResult = 99;

            availableRentalFeaturesMock.Setup(x => x.EstimatePurchasedFeaturesFee()).Returns(expectedResult);

            rental = new Rental(availableVehiculesMock.Object, availableRentalFeaturesMock.Object, 0, 0);

            Assert.AreEqual(expectedResult, rental.EstimatePurchasedFeaturesFee().CalculatedPurchasedFeaturesFee);
            availableRentalFeaturesMock.Verify(x => x.EstimatePurchasedFeaturesFee(), Times.Once);
        }

        [Test]
        public void EstimateTotalRental_Tests()
        {
            const decimal expectedEstimatePurchasedFeaturesFee = 99;
            const decimal expectedFeePerDay = 1;
            const decimal expectedFeePerTraveledMetricUnit = 2;
            const decimal expectedResult = 102;

            availableRentalFeaturesMock.Setup(x => x.EstimatePurchasedFeaturesFee()).Returns(expectedEstimatePurchasedFeaturesFee);

            vehiculeMock.Setup(v => v.FeePerDay).Returns(expectedFeePerDay);
            vehiculeMock.Setup(v => v.FeePerTraveledMetricUnit).Returns(expectedFeePerTraveledMetricUnit);

            availableVehiculesMock.Setup(v => v.GetRentalVehicule()).Returns(vehiculeMock.Object);

            rental = new Rental(availableVehiculesMock.Object, availableRentalFeaturesMock.Object, 1, 1);

            Assert.AreEqual(expectedResult,
                rental
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

            rental = new Rental(availableVehiculesMock.Object, availableRentalFeaturesMock.Object, 0, 0);

            Assert.AreSame(expectedResult, rental.GetPurchasedFeatures());
            availableRentalFeaturesMock.Verify(x => x.GetPurchasedFeatures(), Times.Once);
        }

        [Test]
        public void AddFeature_Tests()
        {
            availableRentalFeaturesMock.Setup(x => x.AddFeature<IRentalFeature>()).Returns(availableRentalFeaturesMock.Object);

            rental = new Rental(availableVehiculesMock.Object, availableRentalFeaturesMock.Object, 0, 0);

            rental.AddFeature<IRentalFeature>();
            availableRentalFeaturesMock.Verify(x => x.AddFeature<IRentalFeature>(), Times.Once);
        }

        [Test]
        public void RemoveFeature_Tests()
        {
            availableRentalFeaturesMock.Setup(x => x.RemoveFeature<IRentalFeature>()).Returns(availableRentalFeaturesMock.Object);

            rental = new Rental(availableVehiculesMock.Object, availableRentalFeaturesMock.Object, 0, 0);

            rental.RemoveFeature<IRentalFeature>();
            availableRentalFeaturesMock.Verify(x => x.RemoveFeature<IRentalFeature>(), Times.Once);
        }

        [Test]
        public void GetRentalVehicule_Tests()
        {
            availableVehiculesMock.Setup(x => x.GetRentalVehicule()).Returns(vehiculeMock.Object);

            rental = new Rental(availableVehiculesMock.Object, availableRentalFeaturesMock.Object, 0, 0);

            var actualResult = rental.GetRentalVehicule();

            availableVehiculesMock.Verify(x => x.GetRentalVehicule(), Times.Once);
            Assert.AreEqual(vehiculeMock.Object, actualResult);
        }

        [Test]
        public void RentVehicule_Tests()
        {
            availableVehiculesMock.Setup(x => x.RentVehicule<IVehicule>()).Returns(availableVehiculesMock.Object);

            rental = new Rental(availableVehiculesMock.Object, availableRentalFeaturesMock.Object, 0, 0);

            rental.RentVehicule<IVehicule>();
            availableVehiculesMock.Verify(x => x.RentVehicule<IVehicule>(), Times.Once);
        }
    }
}