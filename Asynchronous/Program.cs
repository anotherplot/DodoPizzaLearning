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
            
            MoveCar(MoveCar);
            
            while (!isActionCalled)
            {
                Thread.Sleep(1000);
                isActionCalled = true;
            }
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
        }
    }
}