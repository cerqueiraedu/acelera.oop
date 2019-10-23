using System.Linq;
using Acelera.OO.CarRental.Entities.Vehicules;
using Acelera.OO.CarRental.Entities.Vehicules.Interfaces;
using Acelera.OO.CarRental.Entities.Vehicules.Types;
using NUnit.Framework;

namespace Acelera.OO.CarRental.Tests.Entities.Vehicules
{
    [TestFixture]
    public class CarAvailableRentalsTests
    {
        IAvailableVehicules carAvailableRentals;

        [SetUp]
        public void Setup()
        {
            carAvailableRentals = new CarAvailableRentals();
        }

        [Test]
        public void GetAvailableVehiculesTests()
        {
            var actualResult = carAvailableRentals.GetAvailableVehicules();
            Assert.AreEqual(1, actualResult.Count);
            Assert.IsInstanceOf<Car>(actualResult.First());
        }

        [Test]
        public void GetRentalVehiculeTests()
        {
            var actualResult = carAvailableRentals.RentVehicule<Car>().GetRentalVehicule();
            Assert.IsInstanceOf<Car>(actualResult);
        }

        [Test]
        public void RentMotorHomeTests()
        {
            var actualResult = carAvailableRentals.RentVehicule<MotorHome>().GetRentalVehicule();
            Assert.IsNull(actualResult);
        }
    }
}