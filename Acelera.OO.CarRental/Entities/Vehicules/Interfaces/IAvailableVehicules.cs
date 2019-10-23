using System.Collections.Generic;
using Acelera.OO.CarRental.Entities.Vehicules.Types.Interfaces;

namespace Acelera.OO.CarRental.Entities.Vehicules.Interfaces
{
    public interface IAvailableVehicules
    {
        IReadOnlyList<IVehicule> GetAvailableVehicules();
        IVehicule GetRentalVehicule();
        IAvailableVehicules RentVehicule<T>() where T : IVehicule;
    }
}