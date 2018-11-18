using ContainerTests.TestClasses.Character.Interfaces;
using ContainerTests.TestClasses.Weapon.Interfaces;
using System;

namespace ContainerTests.TestClasses.Character
{
    class Sith : IHuman, IWarrior
    {
        readonly IWeapon weapon;

        public Sith(IWeapon weapon)
        {
            this.weapon = weapon;
        }

        public void KillLikeWarrior()
        {
            Console.WriteLine("I WILL FUCK JEDIS!");
            weapon.Kill();
        }

        public void Kill()
        {
            Console.WriteLine("I find your lack of faith disturbing");
            weapon.Kill();
        }
    }
}
