using System.Linq;
using Acelera.OO.CarRental.Entities.Vehicules;
using Acelera.OO.CarRental.Entities.Vehicules.Interfaces;
using Acelera.OO.CarRental.Entities.Vehicules.Types;
using NUnit.Framework;

namespace Acelera.OO.CarRental.Tests.Entities.Vehicules
{
    [TestFixture]
    public class MotorHomeAvailableRentalsTests
    {
        IAvailableVehicules motorHomeAvailableRentals;

        [SetUp]
        public void Setup()
        {
            motorHomeAvailableRentals = new MotorHomeAvailableRentals();
        }

        [Test]
        public void GetAvailableVehiculesTests()
        {
            var actualResult = motorHomeAvailableRentals.GetAvailableVehicules();
            Assert.AreEqual(1, actualResult.Count);
            Assert.IsInstanceOf<MotorHome>(actualResult.First());
        }

        [Test]
        public void GetRentalVehiculeTests()
        {
            var actualResult = motorHomeAvailableRentals.RentVehicule<MotorHome>().GetRentalVehicule();
            Assert.IsInstanceOf<MotorHome>(actualResult);
        }

        [Test]
        public void RentMotorHomeTests()
        {
            var actualResult = motorHomeAvailableRentals.RentVehicule<Car>().GetRentalVehicule();
            Assert.IsNull(actualResult);
        }
    }
}