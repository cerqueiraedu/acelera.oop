using CarRental.Entities.RentalFeatures.FeatureTypes;
using CarRental.Entities.RentalFeatures.FeatureTypes.Interfaces;
using NUnit.Framework;

namespace Acelera.OO.CarRental.Tests.Entities.RentalFeatures.FeatureTypes
{
    [TestFixture]
    public class CarSeatFeatureTests
    {
        IRentalFeature carSeatFeature;

        [TestCase(0)]
        [TestCase(15)]
        [TestCase(25)]
        [TestCase(35)]
        public void CarSeatFeature_Fee_Tests(decimal expectedFee)
        {
            carSeatFeature = new CarSeatFeature(expectedFee);
            Assert.AreEqual(expectedFee, carSeatFeature.Fee);
        }
    }
}
