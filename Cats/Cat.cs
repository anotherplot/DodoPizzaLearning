using System;

namespace Cats
{
    public class Cat : IMakeSound
    {
        public void MakeSound() => Console.WriteLine("Meow!");
    }

}