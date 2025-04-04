using DoctorBooking.Host.Exceptions.Base;

namespace DoctorBooking.Host.Filters.Exceptions
{
    public class ConflictException : AppException
    {
        public ConflictException() : this(string.Empty)
        {
        }

        public ConflictException(string? message) : this(message, null)
        {
        }

        public ConflictException(string? message, Exception? innerException) : base(string.IsNullOrWhiteSpace(message) ? "Conflict occured" : message, innerException)
        {

            Type = TypeBase + "conflict";
            Status = 409;
            Title = "Conflict";
            Code = "Conflict";
        }

    }
}
