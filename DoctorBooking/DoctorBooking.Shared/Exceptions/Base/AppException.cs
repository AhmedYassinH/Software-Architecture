namespace DoctorBooking.Host.Exceptions.Base
{
   
public class AppException : ApplicationException
{
    public string TypeBase = "https://example.com/problems/";
    public string Type { get; protected set; }
    public int Status { get; set; }
    public string Title { get; set; }
    public string Code { get; set; }


    public AppException() : this(string.Empty)
    {
    }


    public AppException(string? message) : this(message, null)
    {
    }

    public AppException(string? message, Exception? innerException) : base(string.IsNullOrWhiteSpace(message) ? "An error occurred while processing your request" : message, innerException)
    {
        Type = TypeBase + "internal-server-error";
        Code = "InternalError";
        Status = 500;
        Title = "Internal Server Error";


    }


}
}


