using Acelera.OO.CarRental.Entities.Vehicules.Types;
using Acelera.OO.CarRental.Entities.Vehicules.Types.Interfaces;
using NUnit.Framework;

namespace Acelera.OO.CarRental.Tests.Entities.Vehicules.Types
{
    [TestFixture]
    public class CarTests 
    {
        IVehicule car;

        [SetUp]
        public void Setup()
        {
            car = new Car();
        }

        [Test]
        public void FeePerDayTests()
        {
            Assert.AreEqual(50, car.FeePerDay);
        }

        [Test]
        public void FeePerTraveledMetricUnitTests()
        {
            Assert.AreEqual(0.5M, car.FeePerTraveledMetricUnit);
        }

        [Test]
        public void ToStringTests()
        {
            Assert.AreEqual("Car", car.ToString());
        }
    }
}