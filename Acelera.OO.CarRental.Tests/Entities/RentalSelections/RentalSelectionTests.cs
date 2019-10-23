using NUnit.Framework;
using Moq;
using Acelera.OO.CarRental.Entities.RentalSelections;
using Acelera.OO.CarRental.Entities.RentalSelections.Interfaces;

namespace Acelera.OO.CarRental.Tests.Entities.RentalSelections
{

    [TestFixture]
    public class RentalSelectionTests
    {
        IRentalSelection rentalSelection;

        [SetUp]
        public void Setup()
        {
            rentalSelection = new RentalSelection();
        }


        [Test]
        public void VehiculeRental_Tests()
        {
            var actualResult = rentalSelection.VehiculeRental(It.IsAny<decimal>(), It.IsAny<int>());
            Assert.IsInstanceOf<Rental>(actualResult);
        }

        [Test]
        public void MotorHomeRental_Tests()
        {
            var actualResult = rentalSelection.MotorHomeRental(It.IsAny<decimal>(), It.IsAny<int>());
            Assert.IsInstanceOf<Rental>(actualResult);
        }
    }
}