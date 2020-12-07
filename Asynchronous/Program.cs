using System;
using System.Threading;

namespace Asynchronous
{
    class Program
    {
        public static bool isActionCalled;

        static void Main(string[] args)
        {
            var isCarArrived = false;
            MoveCarSync();
            MoveCarSync();
        }

        static void MoveCarSync()
        {
            MoveCar(MoveCar);

            while (!isActionCalled)
            {
                Thread.Sleep(1000);
            }

            isActionCalled = false;
        }

        static void MoveCar(Action callback)
        {
            Timer t = null;
            t = new Timer(_ =>
            {
                callback();
                t?.Dispose();
            }, null, 1000, Int32.MaxValue);
        }

        static void MoveCar()
        {
            Console.WriteLine("Car arrived");
            isActionCalled = true;
        }
    }
}