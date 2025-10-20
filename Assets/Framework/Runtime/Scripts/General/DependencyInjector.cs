namespace J_Framework
{
    public static class DependencyInjector
    {
        public static bool Inject<T>(object target, T dependency)
        {
            IDependentOn<T> dependent = target as IDependentOn<T>;
            if (dependent != null)
            {
                dependent.InjectDependency(dependency);
                return true;
            }

            return false;
        }
    }
}
