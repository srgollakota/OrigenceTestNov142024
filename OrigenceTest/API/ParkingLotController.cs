using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrigenceTest.Models;
using OrigenceTest.Service;

namespace OrigenceTest.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingLotController : ControllerBase
    {
        private readonly IParkingLotService _parkingLotService;
        public ParkingLotController( IParkingLotService parkingLotService)
        {
            this._parkingLotService = parkingLotService;
        }

        /*
         * Design a parking lot using object-oriented principles. 
Here are a few methods that you should be able to run:
- Tell us how many spots are remaining
- Tell us how many total spots are in the parking lot
- Tell us when the parking lot is full
- Tell us when the parking lot is empty
- Tell us when certain spots are full, e.g. when all motorcycle spots are taken
- Tell us how many spots vans are taking up
Assumptions:
- The parking lot can hold motorcycles, cars and vans
- The parking lot has motorcycle spots, car spots and large spots
- A motorcycle can park in any spot
- A car can park in a single compact spot, or a regular spot
A van can park, but it will take up 3 regular spots
These are just a few assumptions.
         
         */

        // parking spot receives 



        /// <summary>
        ///  Returns available parking spots.
        /// </summary>
        /// <returns></returns>
        [HttpGet("availableSpots")]
        public ActionResult<int> GetNumberOfAvailableParkingSpots()
        {

            return _parkingLotService.GetNumberOfAvailableParkingSpots();


        }

        [HttpGet("totalSpots")]
        public ActionResult<int> GetTotalParkingSpots()
        {
            return _parkingLotService.GetTotalParkingSpots();
        }

        [HttpGet("isParkingLotFull")]
        public ActionResult<bool> IsParkingLotFull()
        {
            return _parkingLotService.IsParkingLotFull();
        }
        
        [HttpGet("isParkingLotEmpty")]
        public ActionResult<bool> IsParkingLotEmpty()
        {
            return _parkingLotService.IsParkingLotEmpty();
        }
        
        [HttpGet("getAvailablityByVehcileType")]
        public ActionResult<int> GetAvailablilityByVehicleType([FromQuery] string vehicleType)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(vehicleType))
                {
                    throw new ArgumentException("invalid input param");
                }
                VehicleType vt = VehicleType.None;
                var lower = vehicleType.ToLower();
                if(lower == "car")
                {
                    vt = VehicleType.Car;
                }
                else if(lower == "motorcycle")
                {
                    vt = VehicleType.MotorCycle;
                }
                else if(lower == "van")
                {
                    vt = VehicleType.MotorCycle;
                }

                if(vt == VehicleType.None)
                {
                    throw new ArgumentException("invalid input param");
                }

                var availableSpots = _parkingLotService.GetParkingSpotAvailabilityByVehicleType(vt);
                return availableSpots;

            }
            catch (Exception ex)
            {
                // log the exception and return result
            }

            return 0;
        }


    }

    
}
