using Acelera.OO.CarRental.Entities.RentalFeatures.Interfaces;
using Acelera.OO.CarRental.Entities.Vehicules.Interfaces;

namespace Acelera.OO.CarRental.Entities.RentalSelections.Interfaces
{
    public interface IAvailableRentalSelection
    {
        IAvailableVehicules GetCarAvailableRentals();
        IAvailableRentalFeatures GetCarRentalAvailableFeatures();
        IAvailableVehicules GetMotorHomeAvailableRentals();
        IAvailableRentalFeatures GetMotorHomeRentalAvailableFeatures();
    }
}
