namespace Dependencies
{
    public interface IDependenciesProvider
    {
        void RegisterSingleDependency<T>(T instance);
        T GetSingle<T>();
    }
}