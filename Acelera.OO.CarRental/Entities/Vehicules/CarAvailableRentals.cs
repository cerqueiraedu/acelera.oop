using System;
using System.Collections.Generic;
using Acelera.OO.CarRental.Entities.Vehicules.Abstractions;
using Acelera.OO.CarRental.Entities.Vehicules.Types;
using Acelera.OO.CarRental.Entities.Vehicules.Types.Interfaces;

namespace Acelera.OO.CarRental.Entities.Vehicules
{
    public class CarAvailableRentals : AvailableVehicules
    {
        public CarAvailableRentals() => AvailableRentalVehicules = new Lazy<IReadOnlyList<IVehicule>>(() => new List<IVehicule> {
                new Car()
            });
    }
}