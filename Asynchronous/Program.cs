using System;
using System.Threading;

namespace Asynchronous
{
    class Program
    {
        static void Main(string[] args)
        {
            MoveCarSync();
            MoveCarSync();
        }

        static void MoveCarSync()
        {
            var isActionCalled = false;

            MoveCar(() =>
            {
                Console.WriteLine("Car arrived");
                isActionCalled = true;
            });

            while (!isActionCalled)
            {
                Thread.Sleep(1000);
            }
        }

        static void MoveCar(Action callback)
        {
            Timer t = null;
            t = new Timer(_ =>
            {
                callback();
                t?.Dispose();
            }, null, 5000, Int32.MaxValue);
        }
    }
}