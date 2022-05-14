using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModWar.interfaces;
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

            IGameRenderer gameRenderer = modLoader.GetGameRenderer();
            Assert.IsTrue(gameRenderer is IMocked);
        }
    }

    [ModInjector("Player.Tests")]
    public class TestModPack
    {
        public IGameRenderer gameRenderer;

        public TestModPack(KernelBase kernel)
        {
            gameRenderer = new Mock<IGameRenderer>().Object;

            kernel.Bind<IGameRenderer>().ToConstant(gameRenderer);
        }
    }
}