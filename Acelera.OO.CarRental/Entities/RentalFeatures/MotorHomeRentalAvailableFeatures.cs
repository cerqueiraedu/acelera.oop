using System;
using System.Collections.Generic;
using Acelera.OO.CarRental.Entities.RentalFeatures.Abstractions;
using Acelera.OO.CarRental.Entities.RentalFeatures.Types.Interfaces;
using Acelera.OO.CarRental.Entities.RentalFeatures.Types;

namespace Acelera.OO.CarRental.Entities.RentalFeatures
{
    public class MotorHomeRentalAvailableFeatures : AvailableRentalFeatures
    {
        public MotorHomeRentalAvailableFeatures() 
            => AvailableFeatures = new Lazy<IReadOnlyList<IRentalFeature>>(() => new List<IRentalFeature> {
                new GpsFeature(35),
                new CarSeatFeature(75),
                new RefrigeratorFeature(250)
            });
    }
}