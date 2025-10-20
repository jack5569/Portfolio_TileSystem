namespace J_Framework.Event
{
    public interface IEventListenerGetter<TEventListener> where TEventListener : IEventListener
    {
        TEventListener EventListener { get; }
    }
}
