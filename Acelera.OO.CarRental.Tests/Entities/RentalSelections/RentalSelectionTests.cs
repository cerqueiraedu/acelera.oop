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
        Mock<IAvailableRentalSelection> availableRentalSelectionMock;

        [SetUp]
        public void Setup()
        {
            availableRentalSelectionMock = new Mock<IAvailableRentalSelection>();
            rentalSelection = new RentalSelection(availableRentalSelectionMock.Object);
        }

        [Test]
        public void VehiculeRental_Tests()
        {
            var actualResult = rentalSelection.VehiculeRental(It.IsAny<decimal>(), It.IsAny<int>());
            Assert.IsInstanceOf<Rental>(actualResult);

            availableRentalSelectionMock.Verify(x => x.GetCarAvailableRentals(), Times.Once);
            availableRentalSelectionMock.Verify(x => x.GetCarRentalAvailableFeatures(), Times.Once);
            availableRentalSelectionMock.Verify(x => x.GetMotorHomeAvailableRentals(), Times.Never);
            availableRentalSelectionMock.Verify(x => x.GetMotorHomeRentalAvailableFeatures(), Times.Never);
        }

        [Test]
        public void MotorHomeRental_Tests()
        {
            var actualResult = rentalSelection.MotorHomeRental(It.IsAny<decimal>(), It.IsAny<int>());
            Assert.IsInstanceOf<Rental>(actualResult);

            availableRentalSelectionMock.Verify(x => x.GetCarAvailableRentals(), Times.Never);
            availableRentalSelectionMock.Verify(x => x.GetCarRentalAvailableFeatures(), Times.Never);
            availableRentalSelectionMock.Verify(x => x.GetMotorHomeAvailableRentals(), Times.Once);
            availableRentalSelectionMock.Verify(x => x.GetMotorHomeRentalAvailableFeatures(), Times.Once);
        }
    }
}