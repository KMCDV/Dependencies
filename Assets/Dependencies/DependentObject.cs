using UnityEngine;

namespace Dependencies
{
    public abstract class DependentObject
    {
        public void Register()
        {
            RegisterDependencies(Dependencies.SingleDependencies);
            Debug.Log($"Registered {this.GetType()}");
        }

        public void Resolve()
        {
            ResolveDependencies(Dependencies.SingleDependencies);
        }
        public abstract void RegisterDependencies(IDependenciesProvider dependenciesProvider);
        public abstract void ResolveDependencies(IDependenciesProvider dependenciesProvider);
    }
}