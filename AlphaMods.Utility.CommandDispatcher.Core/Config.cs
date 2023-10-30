using AlphaMods.Utility.CommandDispatcher.Interfaces;
using ModWar;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMods.Utility.CommandDispatcher.Core
{
    [ModInjector("AlphaMods.Utility.CommandDispatcher.Core")]
    public class Config
    {
        public Config(KernelBase kernel)
        {
            kernel.Bind<ICommandDispatcher>().To<CommandDispatcher>().InSingletonScope();
        }
    }
}
