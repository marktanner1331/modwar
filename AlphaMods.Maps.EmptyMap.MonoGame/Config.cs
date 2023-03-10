using ModWar;
using ModWar.Interfaces.Config;
using Ninject;

namespace AlphaMods.Maps.EmptyMap.MonoGame
{
    [ModInjector("AlphaMods.Maps.EmptyMap.MonoGame")]
    public class Config : ISetup
    {
        private KernelBase kernel;

        public Config(KernelBase kernel)
        {
            this.kernel = kernel;
            kernel.Bind<MapRenderer>().ToSelf().InSingletonScope();
        }

        public void Setup()
        {
            kernel.Get<MapRenderer>();
        }

    }
}