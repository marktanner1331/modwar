using ModWar;
using ModWar.interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMods
{
    [ModInjector("Alpha Mods")]
    public class AlphaMods
    {
        public AlphaMods(KernelBase kernel)
        {
            kernel.Bind<IGameRenderer>().To<GameRenderer>();
        }
    }
}
