using System.Threading.Tasks;
using DI;
using NUnit.Framework;

namespace TasksTests
{
    public class DeliveryServiceTests
    {
        [Test]
        public async Task METHOD()
        {

            var client = new GoogleMapsClient();
            var deliveryService = new DeliveryService(client);
            
            var clientAddress = "efe";
            var pizzeriaAddress = "efe";
            var result = await deliveryService.EstimateDistance(clientAddress, pizzeriaAddress);

        }
    }
}