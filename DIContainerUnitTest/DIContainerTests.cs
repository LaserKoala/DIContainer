using ContainerTests.TestClasses.Weapon;
using ContainerTests.TestClasses.Weapon.Interfaces;
using DIContainer.Container;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DIContainerUnitTest
{
    [TestClass]
    public class ContainerTests
    {
        [TestMethod]
        public void SimpleReg()
        {
            var container = new Container();
            container.RegisterType<Sword>();
            var swordInstance = container.Resolve<Sword>();

            Assert.IsNotNull(swordInstance);
            Assert.IsInstanceOfType(swordInstance, typeof(Sword));
        }

        [TestMethod]
        public void SimpleRegAsInterface()
        {
            var container = new Container();
            container.RegisterType<Sword>().As<IWeapon>();
            var weaponInstance = container.Resolve<IWeapon>();

            Assert.IsNotNull(weaponInstance);
            Assert.IsInstanceOfType(weaponInstance, typeof(IWeapon));
        }

        [TestMethod]
        public void SimpleRegSingleInstance()
        {
            var container = new Container();
            container.RegisterType<Sword>().As<IWeapon>().SingleInstance();
            var firstWeapon = container.Resolve<IWeapon>();
            var secondWeapon = container.Resolve<IWeapon>();

            Assert.IsNotNull(firstWeapon);
            Assert.IsNotNull(secondWeapon);
            Assert.AreSame(firstWeapon, secondWeapon);
        }



        [TestMethod]
        public void TryingResolveInterface()
        {

            var container = new Container();
            container.RegisterType<IWeapon>();

            Assert.ThrowsException<InvalidOperationException>(() => container.Resolve<IWeapon>());
        }

        [TestMethod]
        public void TryingResolveNonregisteredType()
        {
            var container = new Container();

            Assert.ThrowsException<ArgumentException>(() => container.Resolve<Sword>());
        }

        [TestMethod]
        public void RegisterTypeAsUnsupportedService()
        {
            var container = new Container();

            Assert.ThrowsException<ArgumentException>(() => container.RegisterType<string>().As<IWeapon>());
        }


        [TestMethod]
        public void RegisterTwoServices()
        {
            var container = new Container();
            container.RegisterType<Rifle>()
                .As<IWeapon>()
                .As<ILasersight>()
                .SingleInstance();
            var lasersightInstance = container.Resolve<ILasersight>();
            var weaponInstance = container.Resolve<IWeapon>();

            Assert.IsNotNull(lasersightInstance);
            Assert.AreSame(lasersightInstance, weaponInstance);
        }
    }
}