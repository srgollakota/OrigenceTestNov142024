using OrigenceTest.Models;

namespace OrigenceTest.Service
{
    public interface IParkingLotService
    {
        int GetNumberOfAvailableParkingSpots();

        int GetTotalParkingSpots();

        bool IsParkingLotFull();

        bool IsParkingLotEmpty();

        int GetParkingSpotAvailabilityByVehicleType(VehicleType vehicleType);

    }
}
