using AlphaMods.Renderer.Interfaces;
using ModWar;
using Ninject;

namespace AlphaMods.Maps.EmptyMap.MonoGame
{
    [ModInjector("AlphaMods.Maps.EmptyMap.MonoGame")]
    public class Config : IModConfig
    {
        private KernelBase kernel;

        public Config(KernelBase kernel)
        {
            this.kernel = kernel;
            kernel.Bind<MapRenderer>().ToSelf().InSingletonScope();
        }

        public void Setup()
        {
            IRenderer renderer = kernel.Get<IRenderer>();
            renderer.AddLayer(kernel.Get<MapRenderer>(), LayerDepth.GROUND);
        }

    }
}