using AlphaMods.Renderer.Interfaces;
using ModWar;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMods.Renderer.MonoGame
{
    [ModInjector("AlphaMods.Renderer.MonoGame")]
    public class Config
    {
        public Config(KernelBase kernel)
        {
            kernel.Bind<MonoGameRenderer>().ToSelf().InSingletonScope();
            var k = kernel.GetHashCode();
            //it's important that we bind each interface to the same instance of the momogame renderer
            kernel.Bind<IRenderer>().ToMethod(x =>
            {
                return x.Kernel.Get<MonoGameRenderer>();
            }).InSingletonScope();
        }
    }
}
