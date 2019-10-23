using System.Linq;
using Acelera.OO.CarRental.Entities.RentalFeatures;
using Acelera.OO.CarRental.Entities.RentalFeatures.Interfaces;
using Acelera.OO.CarRental.Entities.RentalFeatures.Types;
using NUnit.Framework;

namespace Acelera.OO.CarRental.Tests.Entities.RentalFeatures
{
    [TestFixture]
    public class MotorHomeRentalAvailableFeaturesTests
    {
        IAvailableRentalFeatures motorHomeRentalAvailableFeatures;

        [SetUp]
        public void Setup()
        {
            motorHomeRentalAvailableFeatures = new MotorHomeRentalAvailableFeatures(); 
        }

        [Test]
        public void GetFeatures_Tests()
        {
            var features = motorHomeRentalAvailableFeatures.Features;

            Assert.AreEqual(3, features.Count);

            var gpsFeature = features.OfType<GpsFeature>().First();
            Assert.IsInstanceOf<GpsFeature>(gpsFeature);
            Assert.AreEqual(35, gpsFeature.Fee);

            var carSeatFeature = features.OfType<CarSeatFeature>().First();
            Assert.IsInstanceOf<CarSeatFeature>(carSeatFeature);
            Assert.AreEqual(75, carSeatFeature.Fee);

            var refrigeratorFeature = features.OfType<RefrigeratorFeature>().First();
            Assert.IsInstanceOf<RefrigeratorFeature>(refrigeratorFeature);
            Assert.AreEqual(250, refrigeratorFeature.Fee);
        }

        [Test]
        public void AddGpsFeature_Tests()
        {
            var purchasedFeatures = 
            motorHomeRentalAvailableFeatures
                .AddFeature<GpsFeature>()
                .GetPurchasedFeatures();

            Assert.AreEqual(1, purchasedFeatures.Count);
            Assert.AreEqual(35, motorHomeRentalAvailableFeatures.EstimatePurchasedFeaturesFee());

            var feature = purchasedFeatures.First();
            Assert.IsInstanceOf<GpsFeature>(feature);
        }

        [Test]
        public void AddGpsFeature_RemoveGpsFeature_Tests()
        {
            var purchasedFeatures = 
            motorHomeRentalAvailableFeatures
                .AddFeature<GpsFeature>()
                .RemoveFeature<GpsFeature>()
                .GetPurchasedFeatures();

            Assert.AreEqual(0, purchasedFeatures.Count);
            Assert.AreEqual(0, motorHomeRentalAvailableFeatures.EstimatePurchasedFeaturesFee());
        }

        [Test]
        public void AddRefrigeratorFeature_Tests()
        {
            var purchasedFeatures = 
            motorHomeRentalAvailableFeatures
                .AddFeature<RefrigeratorFeature>()
                .GetPurchasedFeatures();

            Assert.AreEqual(1, purchasedFeatures.Count);
            Assert.AreEqual(250, motorHomeRentalAvailableFeatures.EstimatePurchasedFeaturesFee());

            var feature = purchasedFeatures.First();
            Assert.IsInstanceOf<RefrigeratorFeature>(feature);
        }

        [Test]
        public void AddRefrigeratorFeature_RemoveRefrigeratorFeature_Tests()
        {
            var purchasedFeatures = 
            motorHomeRentalAvailableFeatures
                .AddFeature<RefrigeratorFeature>()
                .RemoveFeature<RefrigeratorFeature>()
                .GetPurchasedFeatures();

            Assert.AreEqual(0, purchasedFeatures.Count);
            Assert.AreEqual(0, motorHomeRentalAvailableFeatures.EstimatePurchasedFeaturesFee());
        }

        [Test]
        public void AddCarSeatFeature_Tests()
        {
            var purchasedFeatures = 
            motorHomeRentalAvailableFeatures
                .AddFeature<CarSeatFeature>()
                .GetPurchasedFeatures();

            Assert.AreEqual(1, purchasedFeatures.Count);
            Assert.AreEqual(75, motorHomeRentalAvailableFeatures.EstimatePurchasedFeaturesFee());

            var feature = purchasedFeatures.First();
            Assert.IsInstanceOf<CarSeatFeature>(feature);
        }

        [Test]
        public void AddCarSeatFeature_RemoveCarSeatFeature_Tests()
        {
            var purchasedFeatures = 
            motorHomeRentalAvailableFeatures
                .AddFeature<CarSeatFeature>()
                .RemoveFeature<CarSeatFeature>()
                .GetPurchasedFeatures();

            Assert.AreEqual(0, purchasedFeatures.Count);
            Assert.AreEqual(0, motorHomeRentalAvailableFeatures.EstimatePurchasedFeaturesFee());
        }

        [Test]
        public void RemoveAllFeatures_Tests()
        {
            var purchasedFeatures = 
            motorHomeRentalAvailableFeatures
                .RemoveFeature<CarSeatFeature>()
                .RemoveFeature<GpsFeature>()
                .RemoveFeature<RefrigeratorFeature>()
                .GetPurchasedFeatures();

            Assert.AreEqual(0, purchasedFeatures.Count);
            Assert.AreEqual(0, motorHomeRentalAvailableFeatures.EstimatePurchasedFeaturesFee());
        }

        [Test]
        public void AddAllFeatures_Tests()
        {
            var purchasedFeatures = 
            motorHomeRentalAvailableFeatures
                .AddFeature<CarSeatFeature>()
                .AddFeature<GpsFeature>()
                .AddFeature<RefrigeratorFeature>()
                .GetPurchasedFeatures();

            Assert.AreEqual(3, purchasedFeatures.Count);
            Assert.AreEqual(360, motorHomeRentalAvailableFeatures.EstimatePurchasedFeaturesFee());
        }
    }
}
