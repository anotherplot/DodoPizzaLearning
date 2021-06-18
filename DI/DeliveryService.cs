using System.Threading.Tasks;
using System.Device.Location;

namespace DI
{
    public class DeliveryService
    {
        private readonly IMapsClient _maps;

        public DeliveryService(IMapsClient maps)
        {
            _maps = maps;
        }

        // "Прикинуть" расстояние между адресом пиццерии и клиента
        public async Task<DistanceEstimation> EstimateDistance(string pizzeriaAddress, string customerAddress)
        {
            var pizzeriaCoordinates = await _maps.GetAddressCoordinates(pizzeriaAddress);
            var customerCoordinates = await _maps.GetAddressCoordinates(customerAddress);

            // return DistanceEstimation.Near;
            var rawDistance = pizzeriaCoordinates.RawDistanceTo(customerCoordinates);
            return rawDistance switch
            {
                _ when rawDistance < 3 => DistanceEstimation.Near,
                _ when rawDistance < 10 => DistanceEstimation.SomewhatFar,
                _ => DistanceEstimation.VeryFar
            };
        }
    }

    public struct Coordinates
    {
        public float Longitude { get; set; }
        public float Latitude { get; set; }

        const int EarthRadius = 6371;

        public float RawDistanceTo(Coordinates otherCoords)
        {
            // Тут хитроумный алгоритм из двух координат с долготой и широтой в градусах
            // вычисляет расстояние в километрах

            var sCoord = new GeoCoordinate(Latitude, Longitude);
            var eCoord = new GeoCoordinate(otherCoords.Latitude, otherCoords.Longitude);

            return (float) sCoord.GetDistanceTo(eCoord);
        }
    }

    public enum DistanceEstimation
    {
        Near,
        SomewhatFar,
        VeryFar
    }
}