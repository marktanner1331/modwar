using ModWar;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMods.Renderer.TopDown.MonoGame
{
    [ModInjector("AlphaMods.Renderer.TopDown.MonoGame")]
    public class Config
    {
        public Config(KernelBase kernel)
        {
            kernel.Bind<MonoGameRenderer>().ToSelf().InSingletonScope();
            kernel.Bind<IGameStart>().ToMethod(x => x.Kernel.Get<MonoGameRenderer>()).InSingletonScope();
        }
    }
}
