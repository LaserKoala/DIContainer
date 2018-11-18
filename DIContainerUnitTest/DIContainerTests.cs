using ContainerTests.TestClasses.Weapon;
using ContainerTests.TestClasses.Weapon.Interfaces;
using DIContainer.Container;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
            var someInstance = container.Resolve<IWeapon>();

            Assert.IsNotNull(someInstance);
            Assert.IsInstanceOfType(someInstance, typeof(IWeapon));
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