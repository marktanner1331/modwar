using AlphaMods.GameEngine.Interfaces;
using ModWar;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMods.GameEngine.Core
{
    [ModInjector("AlphaMods.GameEngine.Core")]
    public class Config
    {
        public Config(KernelBase kernel)
        {
            kernel.Bind<IGameStart>().To<GameEngine>().InSingletonScope();
            kernel.Bind<IGameEngine>().To<GameEngine>().InSingletonScope();
        }
    }
}
