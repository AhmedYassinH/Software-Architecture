
namespace DoctorBooking.Shared.Core
{
    public interface IAppLogger<T>
    {
        void LogInformation(string message);
        void LogError(string message);
        void LogError(Exception exception, string message);
        void LogWarning(string message);
        void LogDebug(string message);
        void LogCritical(string message);
        void LogTrace(string message);
       
    }
}
