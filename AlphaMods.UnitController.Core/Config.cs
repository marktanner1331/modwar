using AlphaMods.UnitController.Interfaces;
using ModWar;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMods.UnitController.Core
{
    [ModInjector("AlphaMods.UnitController.Core")]
    public class Config
    {
        public Config(KernelBase kernel)
        {
            kernel.Bind<IUnitController>().To<UnitController>().InSingletonScope();
        }
    }
}
