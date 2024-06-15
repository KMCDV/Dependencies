using System;
using UnityEngine;

namespace Dependencies
{
    public abstract class DependentMonoBehaviour : MonoBehaviour
    {
        public virtual void Awake()
        {
            RegisterDependencies(Dependencies.SingleDependencies);
        }

        public virtual void Start()
        {
            ResolveDependencies(Dependencies.SingleDependencies);
        }

        public void RefreshResolve() => ResolveDependencies(Dependencies.SingleDependencies);

        public abstract void RegisterDependencies(IDependenciesProvider dependenciesProvider);
        public abstract void ResolveDependencies(IDependenciesProvider dependenciesProvider);
    }
}