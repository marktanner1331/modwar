using System;
using System.Collections.Generic;
using System.Text;

namespace ModWar.interfaces
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ModInjector : Attribute
    {
        public string ModName { get; }

        public ModInjector(string modName)
        {
            ModName = modName;
        }
    }
}
