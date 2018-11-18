using ContainerTests.TestClasses.Character.Interfaces;
using ContainerTests.TestClasses.Weapon.Interfaces;
using System;

namespace ContainerTests.TestClasses.Character
{
    class Jedi : IHuman, IWarrior
    {
        readonly IWeapon weapon;

        public Jedi(IWeapon weapon)
        {
            this.weapon = weapon;
        }

        public void KillLikeWarrior()
        {
            Console.WriteLine("I WILL FUCK SITHS!");
            weapon.Kill();
        }

        public void Kill()
        {
            Console.WriteLine("There’s always a bigger fish");
            weapon.Kill();
        }
    }
}
