using ModWar;
using ModWar.Interfaces.Config;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMods.Units.CircleTank.TopDown.MonoGame
{
    [ModInjector("AlphaMods.Units.CircleTank.TopDown.MonoGame")]
    public class Config : ISetup
    {
        private KernelBase kernel;

        public Config(KernelBase kernel)
        {
            this.kernel = kernel;
            kernel.Bind<CircleTankUnitController>().ToSelf().InSingletonScope();
            kernel.Bind<Renderer>().ToSelf().InSingletonScope();
        }

        public void Setup()
        {
            //run the constructors
            kernel.Get<CircleTankUnitController>();
            kernel.Get<Renderer>();
        }
    }
}
