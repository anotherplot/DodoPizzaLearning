using System;
using System.Threading.Tasks;

namespace DI
{
    public class DeliveryService {
        private readonly GoogleMapsClient _maps;
        public DeliveryService(GoogleMapsClient maps) {
            _maps = maps;
        }
        // "Прикинуть" расстояние между адресом пиццерии и клиента
        public async Task<DistanceEstimation> EstimateDistance(string pizzeriaAddress, string customerAddress) {
            var pizzeriaCoordinates = await _maps.GetAddressCoordinates(pizzeriaAddress);
            var customerCoordinates = await _maps.GetAddressCoordinates(customerAddress);

            return DistanceEstimation.Near;
            // return pizzeriaCoordinates.RawDistanceTo(customerCoordinates) switch
            // {
            //     // Меньше 3 км - рядом
            //     < 3 => DistanceEstimation.Near,
            //     // от 3 до 10 км - далековато
            //     < 10 => DistanceEstimation.SomewhatFar,
            //     // больше 10 км - очень далеко
            //     _ => DistanceEstimation.VeryFar
            // };
        }
        
    }
    public struct Coordinates {
        public float Longitude { get; set; }
        public float Latitude { get; set; }

        public float RawDistanceTo(Coordinates otherCoords) {
            // Тут хитроумный алгоритм из двух координат с долготой и широтой в градусах
            // вычисляет расстояние в километрах
            return 9f;
        }
    }

    public enum DistanceEstimation {
        Near,
        SomewhatFar,
        VeryFar
    }
}