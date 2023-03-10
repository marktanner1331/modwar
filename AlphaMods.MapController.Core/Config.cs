using AlphaMods.Renderer.Interfaces;
using ModWar;
using ModWar.Interfaces.Config;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMods.MapController.Core
{
    [ModInjector("AlphaMods.MapController.Core")]
    public class Config : ISetup
    {
        private KernelBase kernel;

        public Config(KernelBase kernel)
        {
            this.kernel = kernel;
            kernel.Bind<MapController>().ToSelf().InSingletonScope();
        }

        public void Setup()
        {
            MapController MapController = kernel.Get<MapController>();
            kernel.Get<IRenderer>().AddLayer(MapController.MapRenderer, LayerDepth.GROUND);
        }
    }
}
