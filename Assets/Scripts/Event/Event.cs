using System;

class Event<T> where T : EventArgs
{
    public class Subscriber : IEventSubscriber
    {
        private Event<T>.Delegate func_;

        public Subscriber(Event<T>.Delegate func)
        {
            func_ = func;
        }

        void IEventSubscriber.Subscribe()
        {
            Event<T>.Subscribe(func_);
        }

        void IEventSubscriber.Unsubscribe()
        {
            Event<T>.Unsubscribe(func_);
        }
    }

    public delegate void Delegate(T data);

    private static event Delegate _event;

    public static void Subscribe(Delegate func)
    {
        _event = (Delegate)System.Delegate.Combine(_event, func);
    }

    public static void Unsubscribe(Delegate func)
    {
        _event = (Delegate)System.Delegate.Remove(_event, func);
    }

    public static void Broadcast(T data)
    {
        if (_event != null)
        {
            _event(data);
        }
    }
}
