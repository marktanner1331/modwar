using ModWar;
using ModWar.Interfaces.Config;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMods.Misc.StartingUnits
{
    [ModInjector("AlphaMods.Misc.StartingUnits")]
    public class Config : IBeforeStart
    {
        private readonly KernelBase kernel;

        public Config(KernelBase kernel)
        {
            this.kernel = kernel;
            kernel.Bind<StartingMods>().ToSelf().InSingletonScope();
        }

        public void BeforeStart()
        {
            kernel.Get<StartingMods>().AddUnits();
        }
    }
}
