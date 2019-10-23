namespace Acelera.OO.CarRental.Entities.Vehicules.Types.Interfaces
{
    public interface IVehicule
    {
        decimal FeePerDay { get; }
        decimal FeePerTraveledMetricUnit { get; }

        string ToString();
    }
}