namespace Hafta2.Odev2.Exceptions
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
