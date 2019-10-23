using System;
using System.Collections.Generic;
using Acelera.OO.CarRental.Entities.RentalFeatures.Abstractions;
using Acelera.OO.CarRental.Entities.RentalFeatures.Types.Interfaces;
using Acelera.OO.CarRental.Entities.RentalFeatures.Types;

namespace Acelera.OO.CarRental.Entities.RentalFeatures
{
    public class CarRentalAvailableFeatures : AvailableRentalFeatures
    {
        public CarRentalAvailableFeatures() 
            => AvailableFeatures = new Lazy<IReadOnlyList<IRentalFeature>>(() => new List<IRentalFeature> {
                new GpsFeature(25),
                new CarSeatFeature(65)
            });
    }
}