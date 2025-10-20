namespace J_Framework
{
    public interface IDependentOn<T>
    {
        void InjectDependency(T dependency);
    }
}
