using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MoveCarTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Test1();
             MoveCar(() => Console.WriteLine("Car arrived"));
             MoveCar(() => Console.WriteLine("Car arrived"));
             MoveCar(() => Console.WriteLine("Car arrived"));
            // await MoveCar();
            // await MoveCar();
        }
        
        static void MoveCar(Action callback)
        {
            Timer t = null;
            t = new Timer( _=>
            {
                callback();
                t?.Dispose();
            }, null, 5, 190);
        }

        static async Task Test1() {
            Task<int> task1 = Task.FromResult(42);
            var value1 = await task1;
            Debug.Assert(value1 == 42);
            
            Task task2 = Task.Delay(TimeSpan.FromSeconds(3));
            var watch = Stopwatch.StartNew();
            // task2.Wait();
             await task2;
            Debug.Assert(task2.IsCompleted);
            // Используем 2.5 вместо 3 потому что часы имеют погрешность
            Debug.Assert(watch.Elapsed.TotalSeconds >= 2.5);

        }
    }
}