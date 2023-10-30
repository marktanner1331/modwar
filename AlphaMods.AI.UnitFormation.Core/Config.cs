using AlphaMods.AI.UnitFormation.Interfaces;
using ModWar;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMods.AI.UnitFormation.Core
{
    [ModInjector("AlphaMods.AI.UnitFormation.Core")]
    public class Config
    {
        public Config(KernelBase kernel)
        {
            kernel.Bind<IFormationController>().To<FormationController>().InSingletonScope();
        }
    }
}
