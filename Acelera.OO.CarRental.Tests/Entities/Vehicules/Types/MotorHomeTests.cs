using Acelera.OO.CarRental.Entities.Vehicules.Types;
using Acelera.OO.CarRental.Entities.Vehicules.Types.Interfaces;
using NUnit.Framework;

namespace Acelera.OO.CarRental.Tests.Entities.Vehicules.Types
{
    [TestFixture]
    public class MotorHomeTests
    {
        IVehicule motorHome;

        [SetUp]
        public void Setup()
        {
            motorHome = new MotorHome();
        }

        [Test]
        public void FeePerDayTests()
        {
            Assert.AreEqual(300, motorHome.FeePerDay);
        }

        [Test]
        public void FeePerTraveledMetricUnitTests()
        {
            Assert.AreEqual(0.65M, motorHome.FeePerTraveledMetricUnit);
        }

        [Test]
        public void ToStringTests()
        {
            Assert.AreEqual("Motor Home", motorHome.ToString());
        }
    }
}