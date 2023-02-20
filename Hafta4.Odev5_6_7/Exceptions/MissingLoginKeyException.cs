namespace Hafta4.Odev5_6_7.Exceptions
{
    public class MissingLoginKeyException : Exception
    {
        public MissingLoginKeyException() : base("Unauthorized attempt. Please login then try again!")
        {
        }

        public MissingLoginKeyException(string? message) : base(message)
        {
        }

        public MissingLoginKeyException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
