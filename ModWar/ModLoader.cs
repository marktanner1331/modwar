using ModWar;
using ModWar.Interfaces.Config;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ModWar
{
    public class ModLoader
    {
        private Dictionary<string, Type> mods;
        private KernelBase kernel;

        public ModLoader()
        {
            kernel = new StandardKernel();
            RefreshModList();
        }

        public T Get<T>()
        {
            return kernel.Get<T>();
        }

        public void LoadMods(params string[] modNames)
        {
            LoadMods((IEnumerable<string>)modNames);
        }

        public void LoadMods(IEnumerable<string> modNames)
        {
            kernel = new StandardKernel();
            kernel.Bind<KernelBase>().ToConstant(kernel).InSingletonScope();

            List<object> modConfigs = new List<object>();

            foreach (string modName in modNames)
            {
                kernel.Bind(mods[modName]).To(mods[modName]).InSingletonScope();
                 
                var mod = kernel.Get(mods[modName]);
                modConfigs.Add(mod);
            }

            foreach(var mod in modConfigs)
            {
                if(mod is ISetup setup)
                {
                    setup.Setup();
                }
            }

            foreach (var mod in modConfigs)
            {
                if (mod is IBeforeStart beforeStart)
                {
                    beforeStart.BeforeStart();
                }
            }
        }

        public IEnumerable<string> ListModPacks()
        {
            return mods.Keys;
        }

        /// <summary>
        /// refreshes all mod packs that are available to be loaded
        /// </summary>
        public void RefreshModList()
        {
            mods = new Dictionary<string, Type>();

            string binFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            foreach(string file in Directory.EnumerateFiles(binFolder, "*.dll"))
            {
                Assembly assembly = Assembly.LoadFrom(file);
                
                foreach(Type type in assembly.GetExportedTypes())
                {
                    Attribute[] attrs = Attribute.GetCustomAttributes(type);

                    foreach (Attribute attr in attrs)
                    {
                        if (attr is ModInjector)
                        {
                            ModInjector a = (ModInjector)attr;
                            mods[a.ModName] = type;
                            break;
                        }
                    }
                }
            }
        }
    }
}
