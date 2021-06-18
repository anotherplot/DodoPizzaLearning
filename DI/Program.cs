using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddTransient<IMapsClient, TestMapsClient>();
            services.AddTransient<DeliveryService>();
            var provider = services.BuildServiceProvider();

            var clientAddress = "Moscow, ul. Oktyabrya, d.10";
            var pizzeriaAddress = "Moscow, ul. Oktyabrya, d.98";
            
            var deliveryService = provider.GetService<DeliveryService>();
            var distance = await deliveryService.EstimateDistance(clientAddress,pizzeriaAddress);
            Console.WriteLine(distance);
        }
    }
}