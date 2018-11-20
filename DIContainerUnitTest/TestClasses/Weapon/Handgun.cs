using ContainerTests.TestClasses.Weapon.Interfaces;
using System;

namespace ContainerTests.TestClasses.Weapon
{
    class Handgun : IWeapon, ILasersight
    {
        public void Kill()
        {
            Console.WriteLine("Pam! Pam!");
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
