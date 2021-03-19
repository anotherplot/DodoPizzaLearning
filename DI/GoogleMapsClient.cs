using System.Threading.Tasks;

namespace DI
{
    public class GoogleMapsClient : IMapsClient {
        public Task<Coordinates> GetAddressCoordinates(string address) {
            // А тут у нас поднимается HttpClient, ему прокидывается токен, и мы идём в гугл карты
            // Само собой за деньги
            return Task.FromResult(new Coordinates {Longitude = 4f, Latitude = 5f});
        }
    }
}