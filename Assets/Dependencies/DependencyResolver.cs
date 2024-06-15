using System;
using System.Collections.Generic;

namespace Dependencies
{
    internal class DependencyResolver : IDependenciesProvider
    {
        private Dictionary<Type, object> _singleDependencies = new();

        public void RegisterSingleDependency<T>(T instance)
        {
            if(_singleDependencies.ContainsKey(typeof(T)))
                return;
            _singleDependencies.Add(typeof(T), instance);
        }

        public T GetSingle<T>()
        {
            if (_singleDependencies.ContainsKey(typeof(T)))
                return (T)_singleDependencies[typeof(T)];
            return default;
        }
    }
}