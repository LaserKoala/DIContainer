using ContainerTests.TestClasses.Weapon.Interfaces;
using System;

namespace ContainerTests.TestClasses.Weapon
{
    class Rifle : IWeapon, ILasersight
    {
        public void Kill()
        {
            Console.WriteLine("BAM! BAM! BAM!");
        }

        public void TurnOnLasersight()
        {
            Console.WriteLine("*ZZzZZznnn*");
        }

        public void TurnOffLasersight()
        {
            Console.WriteLine("*ZZzZZznnn*");
        }
    }
}
