
namespace DoctorBooking.Shared.Core
{
    public interface IEventBus
    {
        void Subscribe<T>(object subscriber, Type eventType, Action<T> handler);
        void Unsubscribe<T>(object subscriber);
        void Publish<T>(T @event);
    }
}
