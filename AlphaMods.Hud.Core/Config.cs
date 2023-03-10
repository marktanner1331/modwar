using ModWar;
using ModWar.Interfaces.Config;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMods.Hud.Core
{
    [ModInjector("AlphaMods.Hud.Core")]
    public class Config : ISetup
    {
        private KernelBase kernel;

        public Config(KernelBase kernel)
        {
            this.kernel = kernel;
            kernel.Bind<Hud>().ToSelf().InSingletonScope();
        }

        public void Setup()
        {
            //run the constructor
            kernel.Get<Hud>();
        }
    }
}
