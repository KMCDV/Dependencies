using System;
using System.Collections.Generic;

namespace Dependencies
{
    internal static class Dependencies
    {
        private static DependencyResolver _dependencyResolver;
        internal static IDependenciesProvider SingleDependencies => _dependencyResolver ??= new DependencyResolver();
    }
}