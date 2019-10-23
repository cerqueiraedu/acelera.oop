using Acelera.OO.CarRental.Entities.RentalFeatures;
using Acelera.OO.CarRental.Entities.RentalSelections;
using Acelera.OO.CarRental.Entities.RentalSelections.Interfaces;
using Acelera.OO.CarRental.Entities.Vehicules;
using NUnit.Framework;

namespace Acelera.OO.CarRental.Tests.Entities.RentalSelections
{
    [TestFixture]
    public class AvailableRentalSelectionTests
    {
        IAvailableRentalSelection availableRentalSelection;

        [SetUp]
        public void Setup()
        {
            availableRentalSelection = new AvailableRentalSelection();
        }

        [Test]
        public void GetCarAvailableRentals_Tests()
        {
            var actualResult = availableRentalSelection.GetCarAvailableRentals();
            Assert.IsInstanceOf<CarAvailableRentals>(actualResult);
        }

        [Test]
        public void GetCarRentalAvailableFeatures_Tests()
        {
            var actualResult = availableRentalSelection.GetCarRentalAvailableFeatures();
            Assert.IsInstanceOf<CarRentalAvailableFeatures>(actualResult);
        }

        [Test]
        public void GetMotorHomeAvailableRentals_Tests()
        {
            var actualResult = availableRentalSelection.GetMotorHomeAvailableRentals();
            Assert.IsInstanceOf<MotorHomeAvailableRentals>(actualResult);
        }

        [Test]
        public void GetMotorHomeRentalAvailableFeatures_Tests()
        {
            var actualResult = availableRentalSelection.GetMotorHomeRentalAvailableFeatures();
            Assert.IsInstanceOf<MotorHomeRentalAvailableFeatures>(actualResult);
        }
    }
}
