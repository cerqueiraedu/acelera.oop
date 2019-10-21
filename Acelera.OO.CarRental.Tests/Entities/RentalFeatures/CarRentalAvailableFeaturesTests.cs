using System.Linq;
using CarRental.Entities.RentalFeatures;
using CarRental.Entities.RentalFeatures.FeatureTypes;
using CarRental.Entities.RentalFeatures.Interfaces;
using NUnit.Framework;

namespace Acelera.OO.CarRental.Tests.Entities.RentalFeatures
{
    [TestFixture]
    public class CarRentalAvailableFeaturesTests
    {
        IAvailableRentalFeatures carRentalAvailableFeatures;

        [SetUp]
        public void Setup()
        {
            carRentalAvailableFeatures = new CarRentalAvailableFeatures();
        }

        [Test]
        public void GetFeatures_Tests()
        {
            var features = carRentalAvailableFeatures.GetFeatures();

            Assert.AreEqual(2, features.Count);

            var gpsFeature = features.OfType<GpsFeature>().First();
            Assert.IsInstanceOf<GpsFeature>(gpsFeature);
            Assert.AreEqual(25, gpsFeature.Fee);

            var carSeatFeature = features.OfType<CarSeatFeature>().First();
            Assert.IsInstanceOf<CarSeatFeature>(carSeatFeature);
            Assert.AreEqual(65, carSeatFeature.Fee);
        }

        [Test]
        public void AddGpsFeature_Tests()
        {
            var purchasedFeatures = 
            carRentalAvailableFeatures
                .AddFeature<GpsFeature>()
                .GetPurchasedFeatures();

            Assert.AreEqual(1, purchasedFeatures.Count);
            Assert.AreEqual(25, carRentalAvailableFeatures.EstimatePurchasedFeaturesFee());

            var feature = purchasedFeatures.First();
            Assert.IsInstanceOf<GpsFeature>(feature);
        }

        [Test]
        public void AddGpsFeature_RemoveGpsFeature_Tests()
        {
            var purchasedFeatures = 
            carRentalAvailableFeatures
                .AddFeature<GpsFeature>()
                .RemoveFeature<GpsFeature>()
                .GetPurchasedFeatures();

            Assert.AreEqual(0, purchasedFeatures.Count);
            Assert.AreEqual(0, carRentalAvailableFeatures.EstimatePurchasedFeaturesFee());
        }

        [Test]
        public void AddRefrigeratorFeature_Tests()
        {
            //todo: test
        }

        [Test]
        public void AddCarSeatFeature_Tests()
        {
            var purchasedFeatures = 
            carRentalAvailableFeatures
                .AddFeature<CarSeatFeature>()
                .GetPurchasedFeatures();

            Assert.AreEqual(1, purchasedFeatures.Count);
            Assert.AreEqual(65, carRentalAvailableFeatures.EstimatePurchasedFeaturesFee());

            var feature = purchasedFeatures.First();
            Assert.IsInstanceOf<CarSeatFeature>(feature);
        }

        [Test]
        public void AddCarSeatFeature_RemoveCarSeatFeature_Tests()
        {
            var purchasedFeatures = 
            carRentalAvailableFeatures
                .AddFeature<CarSeatFeature>()
                .RemoveFeature<CarSeatFeature>()
                .GetPurchasedFeatures();

            Assert.AreEqual(0, purchasedFeatures.Count);
            Assert.AreEqual(0, carRentalAvailableFeatures.EstimatePurchasedFeaturesFee());
        }

        [Test]
        public void RemoveAllFeatures_Tests()
        {
            var purchasedFeatures = 
            carRentalAvailableFeatures
                .RemoveFeature<CarSeatFeature>()
                .RemoveFeature<GpsFeature>()
                .GetPurchasedFeatures();

            Assert.AreEqual(0, purchasedFeatures.Count);
            Assert.AreEqual(0, carRentalAvailableFeatures.EstimatePurchasedFeaturesFee());
        }

        [Test]
        public void AddAllFeatures_Tests()
        {
            var purchasedFeatures = 
            carRentalAvailableFeatures
                .AddFeature<CarSeatFeature>()
                .AddFeature<GpsFeature>()
                .GetPurchasedFeatures();

            Assert.AreEqual(2, purchasedFeatures.Count);
            Assert.AreEqual(90, carRentalAvailableFeatures.EstimatePurchasedFeaturesFee());
        }
    }
}
