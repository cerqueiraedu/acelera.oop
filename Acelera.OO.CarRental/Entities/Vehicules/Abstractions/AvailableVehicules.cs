using System;
using System.Collections.Generic;
using System.Linq;
using Acelera.OO.CarRental.Entities.Vehicules.Interfaces;
using Acelera.OO.CarRental.Entities.Vehicules.Types.Interfaces;

namespace Acelera.OO.CarRental.Entities.Vehicules.Abstractions
{
    public abstract class AvailableVehicules : IAvailableVehicules
    {
        protected Lazy<IReadOnlyList<IVehicule>> AvailableRentalVehicules;
        protected IVehicule RentalVehicule;

        public IReadOnlyList<IVehicule> GetAvailableVehicules() => AvailableRentalVehicules.Value;

        public IVehicule GetRentalVehicule() => RentalVehicule;

        public IAvailableVehicules RentVehicule<T>() where T : IVehicule
        {
            RentalVehicule = AvailableRentalVehicules.Value.OfType<T>().FirstOrDefault();
            return this;
        }
    }
}