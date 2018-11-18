using ContainerTests.TestClasses.Weapon.Interfaces;
using System;

namespace ContainerTests.TestClasses.Weapon
{
    class Sword : IWeapon
    {
        public void Kill()
        {
            Console.WriteLine("Sllash!");
        }
    }
}
