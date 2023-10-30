using AlphaMods.PlayerController.Interfaces;
using ModWar;
using ModWar.Interfaces.Config;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMods.PlayerController.Core
{
    [ModInjector("AlphaMods.PlayerController.Core")]
    public class Config : IConfigure
    {
        private readonly KernelBase kernel;

        public Config(KernelBase kernel)
        {
            this.kernel = kernel;
            kernel.Bind<PlayerController>().ToSelf().InSingletonScope();
            kernel.Bind<IPlayerController>().ToMethod(x => x.Kernel.Get<PlayerController>()).InSingletonScope();
        }

        public void Configure()
        {
            kernel.Get<PlayerController>().NumPlayers = 2;
        }
    }
}
