using Acelera.OO.CarRental.Entities.RentalFeatures;
using Acelera.OO.CarRental.Entities.RentalFeatures.Interfaces;
using Acelera.OO.CarRental.Entities.RentalSelections.Interfaces;
using Acelera.OO.CarRental.Entities.Vehicules;
using Acelera.OO.CarRental.Entities.Vehicules.Interfaces;

namespace Acelera.OO.CarRental.Entities.RentalSelections
{
    public class AvailableRentalSelection : IAvailableRentalSelection
    {
        public IAvailableVehicules GetCarAvailableRentals() => new CarAvailableRentals();

        public IAvailableRentalFeatures GetCarRentalAvailableFeatures() => new CarRentalAvailableFeatures();

        public IAvailableVehicules GetMotorHomeAvailableRentals() => new MotorHomeAvailableRentals();

        public IAvailableRentalFeatures GetMotorHomeRentalAvailableFeatures() => new MotorHomeRentalAvailableFeatures();
    }
}
