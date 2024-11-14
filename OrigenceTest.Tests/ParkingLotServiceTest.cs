using Xunit;
using OrigenceTest.Service;
using Moq;

namespace OrigenceTest.Tests
{
    public class ParkingLotServiceTest
    {
        private readonly Mock<IParkingLotService> _parkingLotService;
        public ParkingLotServiceTest()
        {
            _parkingLotService = new Mock<IParkingLotService>();
        }

        [Fact]
        public void ParkingLotService_GetNumberOfAvailableParkingSpots_Returns_AvailableSpots()
        {
            // Arrange
            _parkingLotService.Setup(s=>s.GetNumberOfAvailableParkingSpots()).Returns(1);


            // Act
            var availbleSpots = _parkingLotService.Object.GetNumberOfAvailableParkingSpots();

            // Assert
            
            Assert.Equal(1, availbleSpots);
        }

    }
}