using AlphaMods.Maps.MapController.Interfaces;
using ModWar;
using ModWar.Interfaces.Config;
using Ninject;

namespace AlphaMods.Maps.EmptyMap.TopDown.MonoGame
{
    [ModInjector("AlphaMods.Maps.EmptyMap.TopDown.MonoGame")]
    public class Config : ISetup
    {
        private KernelBase kernel;

        public Config(KernelBase kernel)
        {
            this.kernel = kernel;
            kernel.Bind<MapRenderer>().ToSelf().InSingletonScope();
            kernel.Bind<IMapController>().ToMethod(x => x.Kernel.Get<MapRenderer>());
        }

        public void Setup()
        {
            kernel.Get<MapRenderer>();
        }
    }
}