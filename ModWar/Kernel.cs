using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ModWar
{
    public class Kernel
    {
        private Dictionary<Type, object> instances = new Dictionary<Type, object>();
        private Dictionary<Type, Type> bindings = new Dictionary<Type, Type>();

        public KernelTo<T> Bind<T>()
        {
            return new KernelTo<T>(this);
        }

        public T Get<T>()
        {
            return (T)Get(typeof(T));
        }

        public object Get(Type type)
        {
            HashSet<Type> cyclicCache = new HashSet<Type>();

            object inner(Type type)
            {
                if(cyclicCache.Contains(type))
                {
                    throw new Exception("Cyclic error when resolving: " + type);
                }

                if (type.IsClass)
                {
                    if(instances.ContainsKey(type))
                    {
                        return instances[type];
                    }

                    var constructors = type.GetConstructors();
                    if(constructors.Length != 1)
                    {
                        throw new Exception($"{type.FullName} should have exactly one constructor");
                    }

                    ConstructorInfo constructor = constructors[0];

                    object[] parameters = constructor
                        .GetParameters()
                        .Select(x => Get(x.ParameterType))
                        .ToArray();

                    return constructor.Invoke(parameters);
                }
                else if (type.IsInterface)
                {
                    return Get(bindings[type]);
                }
                else
                {
                    throw new Exception("Unknown type: " + type.FullName);
                }
            };

            return inner(type);
        }

        public class KernelTo<T>
        {
            private readonly Kernel kernel;

            internal KernelTo(Kernel kernel)
            {
                this.kernel = kernel;
            }

            public void To<U>()
            {
                kernel.bindings[typeof(T)] = typeof(U);
            }
        }
    }
}
