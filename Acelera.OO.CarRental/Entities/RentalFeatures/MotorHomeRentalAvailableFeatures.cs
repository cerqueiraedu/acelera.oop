using System;
using System.Collections.Generic;
using CarRental.Entities.RentalFeatures.FeatureTypes.Interfaces;
using CarRental.Entities.RentalFeatures.FeatureTypes;
using CarRental.Entities.RentalFeatures.Interfaces;

namespace CarRental.Entities.RentalFeatures
{
    public class MotorHomeRentalAvailableFeatures : AvailableRentalFeatures
    {
        static MotorHomeRentalAvailableFeatures()
        {
            AvailableFeatures = new Lazy<IReadOnlyList<IRentalFeature>>(() => new List<IRentalFeature> { 
                new GpsFeature(35), 
                new CarSeatFeature(75), 
                new RefrigeratorFeature(250) 
            });
        }
    }
}