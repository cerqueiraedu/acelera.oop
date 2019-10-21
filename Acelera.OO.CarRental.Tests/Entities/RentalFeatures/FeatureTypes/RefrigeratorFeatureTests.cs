using CarRental.Entities.RentalFeatures.FeatureTypes;
using CarRental.Entities.RentalFeatures.FeatureTypes.Interfaces;
using NUnit.Framework;

namespace Acelera.OO.CarRental.Tests.Entities.RentalFeatures.FeatureTypes
{
    [TestFixture]
    public class RefrigeratorFeatureTests
    {
        IRentalFeature refrigeratorFeature;

        [TestCase(0)]
        [TestCase(15)]
        [TestCase(25)]
        [TestCase(35)]
        public void RefrigeratorFeature_Fee_Tests(decimal expectedFee)
        {
            refrigeratorFeature = new RefrigeratorFeature(expectedFee);
            Assert.AreEqual(expectedFee, refrigeratorFeature.Fee);
        }
    }
}
