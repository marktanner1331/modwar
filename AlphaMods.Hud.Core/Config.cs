using AlphaMods.Hud.Interfaces;
using AlphaMods.Renderer.Interfaces;
using ModWar;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMods.Hud.Core
{
    [ModInjector("AlphaMods.Hud.Core")]
    public class Config : IModConfig
    {
        private KernelBase kernel;

        public Config(KernelBase kernel)
        {
            this.kernel = kernel;
            kernel.Bind<IHud>().To<Hud>().InSingletonScope();
        }

        public void Setup()
        {
            kernel.Get<IRenderer>().SetRoot(kernel.Get<IHud>().Render);
        }
    }
}
