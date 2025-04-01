

namespace DoctorBooking.Shared.Core
{
    public class EventBus : IEventBus
    {
        private readonly List<EventListener> _eventListeners = new List<EventListener>();
        public void Publish<T>(T @event)
        {
            lock (_eventListeners)
            {
                foreach (var listener in _eventListeners)
                {
                    if (listener.eventType == typeof(T))
                    {
                        var handler = (Action<T>)listener.handler;
                        handler(@event);

                    }
                }
            }
        }

        public void Subscribe<T>(object subscriber, Type eventType, Action<T> handler)
        {
            var eventListener = new EventListener(subscriber, eventType, handler);
            lock (_eventListeners)
            {
                _eventListeners.Add(eventListener);
            }
        }

        public void Unsubscribe<T>(object subscriber)
        {
            lock (_eventListeners)
            {
                _eventListeners.RemoveAll(x => x.subscriber == subscriber);
            }
        }


        private record EventListener(object subscriber, Type eventType, Delegate handler);
    }
}
