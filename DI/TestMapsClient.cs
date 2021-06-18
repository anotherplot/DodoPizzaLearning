using System.Collections.Generic;
using System.Threading.Tasks;

namespace DI
{
    public class TestMapsClient : IMapsClient
    {
        private readonly Dictionary<string, Coordinates> _addressesWithCoordinates = new()
        {
            {"Moscow, ul. Oktyabrya, d.10", new Coordinates {Longitude = 55.763148f, Latitude = 37.629700f}},
            {"Moscow, ul. Oktyabrya, d.98", new Coordinates {Longitude = 55.763141f, Latitude = 37.629704f}},
        };

        // public TestMapsClient(Dictionary<string, Coordinates> addressesWithCoordinates)
        // {
        //     _addressesWithCoordinates = addressesWithCoordinates;
        // }

        public Task<Coordinates> GetAddressCoordinates(string pizzeriaAddress)
        {
            return Task.FromResult(_addressesWithCoordinates.GetValueOrDefault(pizzeriaAddress));
        }
    }
}