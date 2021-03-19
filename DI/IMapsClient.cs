using System.Threading.Tasks;

namespace DI
{
    public interface IMapsClient
    {
        public Task<Coordinates> GetAddressCoordinates(string pizzeriaAddress);
    }
}