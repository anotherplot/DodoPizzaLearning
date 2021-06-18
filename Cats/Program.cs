using Microsoft.Extensions.DependencyInjection;

namespace Cats
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddTransient<IMakeSound, Cat>();
            var provider = services.BuildServiceProvider();
            var makeSound = provider.GetService<IMakeSound>();
            makeSound.MakeSound();
        }
    }
}
