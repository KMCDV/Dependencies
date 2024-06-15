using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace DefaultNamespace
{
    public static class Bootloader
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        public static void Initialize()
        {
            
            var services = CreateRuntimeInstancesOfType<BaseService>();
            services.ForEach(x => x.Register());
            services.ForEach(x => x.Resolve());
        }

        static List<T> CreateRuntimeInstancesOfType<T>() where T : class
        {
            var type = typeof(T);

            return Assembly.GetAssembly(type)
                .GetTypes()
                .Where(x => x.IsSubclassOf(type) && !x.IsAbstract)
                .Select(x => Activator.CreateInstance(x) as T).ToList();
        }
    }
}