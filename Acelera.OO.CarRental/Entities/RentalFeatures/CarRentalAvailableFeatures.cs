using System;
using System.Collections.Generic;
using CarRental.Entities.RentalFeatures.FeatureTypes.Interfaces;
using CarRental.Entities.RentalFeatures.FeatureTypes;
using CarRental.Entities.RentalFeatures.Interfaces;

namespace CarRental.Entities.RentalFeatures
{
    public class CarRentalAvailableFeatures : AvailableRentalFeatures
    {
        static CarRentalAvailableFeatures()
        {
            AvailableFeatures = new Lazy<IReadOnlyList<IRentalFeature>>(() => new List<IRentalFeature> { 
                new GpsFeature(25), 
                new CarSeatFeature(65) 
            });
        }
    }
}