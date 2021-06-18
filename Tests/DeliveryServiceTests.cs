using System.Collections.Generic;
using System.Threading.Tasks;
using DI;
using NUnit.Framework;

namespace TasksTests
{
    public class DeliveryServiceTests
    {
        [Test]
        public async Task DistanceBetweenAddressesShouldBeNear()
        {
            // var clientCoordinates = new Coordinates {Longitude = 55.763148f, Latitude = 37.629700f};
            // var pizzeriaCoordinates = new Coordinates {Longitude = 55.763141f, Latitude = 37.629704f};
            var clientAddress = "Moscow, ul. Oktyabrya, d.10";
            var pizzeriaAddress = "Moscow, ul. Oktyabrya, d.98";
            //
            // var addressesWithCoordinates = new Dictionary<string, Coordinates>()
            // {
            //     {clientAddress, clientCoordinates},
            //     {pizzeriaAddress, pizzeriaCoordinates},
            // };
            var testClient = new TestMapsClient();
            var deliveryService = new DeliveryService(testClient);
            
            var result = await deliveryService.EstimateDistance(clientAddress, pizzeriaAddress);
            Assert.True(result.Equals(DistanceEstimation.Near));
        }
    }
}