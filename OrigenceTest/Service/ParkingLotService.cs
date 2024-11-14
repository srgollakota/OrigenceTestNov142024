using OrigenceTest.Models;

namespace OrigenceTest.Service
{
    public class ParkingLotService : IParkingLotService
    {
        private static List<ParkingSpot> _parkingSpots = new List<ParkingSpot>
        {
            new ParkingSpot{ParkingSpotNumber = 1, IsAvailable= true},
            new ParkingSpot{ParkingSpotNumber = 2, IsAvailable= true},
            new ParkingSpot{ParkingSpotNumber = 3, IsAvailable= true},
              new ParkingSpot{ParkingSpotNumber = 4, IsAvailable= true},
              new ParkingSpot{ParkingSpotNumber = 4, IsAvailable= true},
                  new ParkingSpot{ParkingSpotNumber = 6, IsAvailable= true},
                  new ParkingSpot{ParkingSpotNumber = 7, IsAvailable= true},
                  new ParkingSpot{ParkingSpotNumber = 8, IsAvailable= true},
                    new ParkingSpot{ParkingSpotNumber = 9, IsAvailable= true},
                      new ParkingSpot{ParkingSpotNumber = 10, IsAvailable= true},
        };


        public int GetNumberOfAvailableParkingSpots()
        {
            return _parkingSpots.Count(x => x.IsAvailable == true);
        }

        public int GetParkingSpotAvailabilityByVehicleType(VehicleType vehicleType)
        {
            // assumptions, car and motorcycle need 1 spot and vans need 3 spots

            var availableSpots = _parkingSpots.Count(x => x.IsAvailable == true);
            if (availableSpots == 0) return 0;
            switch (vehicleType)
            {
                case VehicleType.Car:
                    return availableSpots;
                    
                case VehicleType.MotorCycle:
                    return availableSpots;
                    
                case VehicleType.Van:

                    // available spots modulo 3 == 0 return available spots
                    
                    
                    if (availableSpots < 3) return 0;
                    else if (availableSpots % 3 == 0) return availableSpots;
                    break;
                                       
                    
                    
            }

            return availableSpots;
        }

        public int GetTotalParkingSpots()
        {
            return _parkingSpots.Count();
        }

        public bool IsParkingLotEmpty()
        {
            var totalSpots = _parkingSpots.Count;
            return _parkingSpots.Count(x=>x.IsAvailable == true) == totalSpots;
        }

        public bool IsParkingLotFull()
        {
            return _parkingSpots.Count(x => x.IsAvailable == false) == 0;
        }
    }
}
