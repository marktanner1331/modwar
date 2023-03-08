using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModWar;
using Moq;
using Ninject;
using Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Player.Tests
{
    [TestClass()]
    public class ModLoaderTests
    {
        [TestMethod()]
        public void ListModPacksTest()
        {
            ModLoader modLoader = new ModLoader();

            var modPacks = modLoader.ListModPacks();
            Assert.IsTrue(modPacks.Contains("Player.Tests"));

            modLoader.LoadMods("Player.Tests");

            IGameStart gameStart = modLoader.Get<IGameStart>();
            Assert.IsTrue(gameStart is IMocked);
        }
    }

    [ModInjector("Player.Tests")]
    public class TestModPack
    {
        public IGameStart gameStart;

        public TestModPack(KernelBase kernel)
        {
            gameStart = new Mock<IGameStart>().Object;

            kernel.Bind<IGameStart>().ToConstant(gameStart);
        }
    }
}