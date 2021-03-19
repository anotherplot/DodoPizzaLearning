using System.Collections.Generic;
using System.Threading.Tasks;

namespace DI
{
    public class TestMapsClient : IMapsClient
    {
        private readonly Dictionary<string, Coordinates> _addressesWithCoordinates;

        public TestMapsClient(Dictionary<string, Coordinates> addressesWithCoordinates)
        {
            _addressesWithCoordinates = addressesWithCoordinates;
        }

        public Task<Coordinates> GetAddressCoordinates(string pizzeriaAddress)
        {
            return Task.FromResult(_addressesWithCoordinates.GetValueOrDefault(pizzeriaAddress));
        }
    }
}